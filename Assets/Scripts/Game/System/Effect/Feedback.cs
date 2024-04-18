using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Feedback
{
    
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Feedback")]
    public class Feedback : ScriptableObject, IFeedback
    {

        enum FeedbackKind
        {
            SelfMadeFeedback,
            ChangeableFeedback
        }
        [System.Serializable]
        class FeedbackTuple
        {
            public FeedbackKind feedbackKind;
            public Feedback selfMadeFB;
            [SerializeReference, SubclassSelector] public IFeedback changeableFB;
            public bool isWaitForEnd;
            public float intervalTime;
        }

        class ParallelFeedbackInfo
        {
            public Vector2 position;
            public int nowPlayingIndex;
            public float temporaryInterval;
            public Action<int> onFinishedCallback;
            public int parentsFeedbackID;
            public Dictionary<int, int> loopLeftCount = new Dictionary<int, int>();//KeyはFeedbackIndex, Valueは残りループカウント
            public bool isActive = true;
        }
        List<ParallelFeedbackInfo> IDToFeedbackInfo = new List<ParallelFeedbackInfo>();

        [SerializeField] FeedbackTuple[] feedbackTuples;
        public void Play(Vector2 feedbackPosition, Action<int> _onFinishedCallback, int _parentsParallelFeedbackID = -1)
        {
            //終了時に_onFinishedCallback.Invoke(_parentsParallelFeedbackID)を行う
            //呼び出し元などの情報をIDToFeedbackInfoにメモする
            var info = new ParallelFeedbackInfo();
            info.position = feedbackPosition;
            info.nowPlayingIndex = -1;
            info.temporaryInterval = 0;
            info.onFinishedCallback = _onFinishedCallback;
            info.parentsFeedbackID = _parentsParallelFeedbackID;
            int thisParallelID = IDToFeedbackInfo.Count;//今発行されたフィードバックの並列ID(非負)
            IDToFeedbackInfo.Add(info);
            PlayNextFeedback(thisParallelID);
        }
        void PlayNextFeedback(int parallelFeedbackID)
        {
            if (IDToFeedbackInfo[parallelFeedbackID].temporaryInterval != 0)
            {
                //インターバルタイムが設定されている場合ウェイトを挟んで次のフィードバックを再生
                PlayFeedbackAfterFewSeconds(parallelFeedbackID).Forget();
                return;
            }
            var info = IDToFeedbackInfo[parallelFeedbackID];
            info.nowPlayingIndex++;
            if(info.nowPlayingIndex >= feedbackTuples.Length)
            {
                //再生終了を通知
                EndFeedback(parallelFeedbackID);
                return;
            }
            var feedbackTuple = feedbackTuples[info.nowPlayingIndex];
            info.temporaryInterval = feedbackTuple.intervalTime;
            //フィードバックの再生
            if (feedbackTuple.feedbackKind == FeedbackKind.SelfMadeFeedback)
            {
                if (feedbackTuple.isWaitForEnd)
                {
                    feedbackTuple.selfMadeFB.Play(info.position,PlayNextFeedback,parallelFeedbackID);
                    return;
                }
                else
                {
                    feedbackTuple.selfMadeFB.Play(info.position, _ => { }, parallelFeedbackID);
                    PlayNextFeedback(parallelFeedbackID);
                    return;
                }

            }
            else
            {
                //ループ周りの処理
                if (feedbackTuple.changeableFB.GetType() == typeof(LoopEndFB))
                {
                    LoopEndFB loopEndFB = (LoopEndFB)feedbackTuple.changeableFB;
                    if (!info.loopLeftCount.ContainsKey(info.nowPlayingIndex))
                    {
                        info.loopLeftCount.Add(info.nowPlayingIndex, loopEndFB.loopCount);
                        if(loopEndFB.loopCount == 0)
                        {
                            PlayNextFeedback(parallelFeedbackID);
                            return;
                        }
                    }
                    else
                    {
                        info.loopLeftCount[info.nowPlayingIndex]--;
                        if (info.loopLeftCount[info.nowPlayingIndex] == 0)
                        {
                            PlayNextFeedback(parallelFeedbackID);
                            return;
                        }
                    }
                    //ここまででreturnされていない場合、LoopStartFB or インデックス0まで戻る
                    int returningIndex = -1;
                    for(int i = info.nowPlayingIndex-1; i>=0; i--)
                    {
                        if (feedbackTuples[i].feedbackKind == FeedbackKind.ChangeableFeedback)
                        {
                            if (feedbackTuples[i].changeableFB.GetType() == typeof(LoopStartFB))
                            {
                                returningIndex = i;
                            }
                        }
                    }
                    info.nowPlayingIndex = returningIndex;
                    PlayNextFeedback(parallelFeedbackID);
                    return;
                }
                //ループ周りの処理終了
                if (feedbackTuple.isWaitForEnd)
                {
                    feedbackTuple.changeableFB.Play(info.position, PlayNextFeedback, parallelFeedbackID);
                    return;
                }
                else
                {
                    feedbackTuple.changeableFB.Play(info.position, _ => { }, parallelFeedbackID);
                    PlayNextFeedback(parallelFeedbackID);
                    return;
                }
            }

        }
        public void EndFeedback(int parallelFeedbackID)
        {
            var info = IDToFeedbackInfo[parallelFeedbackID];
            if(info.parentsFeedbackID == -1)
            {
                //parentsFeedbackIDが-1の時はFeedbackによる再帰以外での呼び出しなので、parallelFeedbackIDを返す
                info.onFinishedCallback(parallelFeedbackID);
            }
            else
            {
                info.onFinishedCallback(info.parentsFeedbackID);
            }
            info.isActive = false;
            DeleteUnUsedFeedback();
        }

        void DeleteUnUsedFeedback()
        {
            //activeでないフィードバックをインデックスが高い順に削除
            for(int i = IDToFeedbackInfo.Count - 1; i >= 0; i--)
            {
                if (IDToFeedbackInfo[i].isActive)
                {
                    return;
                }
                else
                {
                    IDToFeedbackInfo.RemoveAt(i);
                }
            }
        }
        
        async UniTask PlayFeedbackAfterFewSeconds(int parallelFeedbackID)
        {
            await UniTask.Delay(Mathf.RoundToInt(IDToFeedbackInfo[parallelFeedbackID].temporaryInterval * 1000));
            IDToFeedbackInfo[parallelFeedbackID].temporaryInterval = 0;
            PlayNextFeedback(parallelFeedbackID);
        }
    }


}