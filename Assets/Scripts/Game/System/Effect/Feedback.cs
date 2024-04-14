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
        [SerializeField] FeedbackTuple[] feedbackTuples;
        int nowPlayingFeedbackIndex = 0;//今再生しているのはfeedbackTuples[nowPlayingFeedbackIndex]
        Vector2 nowPlayingFeedbackPosition;//今再生しているフィードバックの座標
        Action onFinishCallback;
        public void Play(Vector2 position,Action _onFinishedCallback)
        {
            nowPlayingFeedbackIndex = 0;
            nowPlayingFeedbackPosition = position;
            onFinishCallback = _onFinishedCallback;
            PlayAfterNowIndex();
        }

        float temporaryInterval = 0;
        void PlayAfterNowIndex()
        {
            //isWaitEnd == trueの時のウェイト設定
            if(temporaryInterval != 0)
            {
                PlayFeedbackAfterFewSeconds(temporaryInterval).Forget();
                temporaryInterval = 0;
                return;
            }
            //今のindex番目以降のフィードバックを再生
            for(;nowPlayingFeedbackIndex < feedbackTuples.Length;)
            {
                var feedbackTuple = feedbackTuples[nowPlayingFeedbackIndex];
                nowPlayingFeedbackIndex++;
                if (feedbackTuple.feedbackKind == FeedbackKind.SelfMadeFeedback)
                {
                    if (feedbackTuple.isWaitForEnd)
                    {
                        temporaryInterval = feedbackTuple.intervalTime;
                        feedbackTuple.selfMadeFB.Play(nowPlayingFeedbackPosition, PlayAfterNowIndex);
                        return;
                    }
                    else if(feedbackTuple.intervalTime != 0)
                    {
                        feedbackTuple.selfMadeFB.Play(nowPlayingFeedbackPosition, () => { });
                        PlayFeedbackAfterFewSeconds(feedbackTuple.intervalTime).Forget();
                        return;
                    }
                    else
                    {
                        feedbackTuple.selfMadeFB.Play(nowPlayingFeedbackPosition, () => { });
                    }

                }
                else
                {
                    if (feedbackTuple.isWaitForEnd)
                    {
                        temporaryInterval = feedbackTuple.intervalTime;
                        feedbackTuple.changeableFB.Play(nowPlayingFeedbackPosition, PlayAfterNowIndex);
                        return;
                    }
                    else if (feedbackTuple.intervalTime != 0)
                    {
                        feedbackTuple.changeableFB.Play(nowPlayingFeedbackPosition, () => { });
                        PlayFeedbackAfterFewSeconds(feedbackTuple.intervalTime).Forget();
                        return;
                    }
                    else
                    {
                        feedbackTuple.changeableFB.Play(nowPlayingFeedbackPosition, () => { });
                    }
                }
            }
            //フィードバック再生が終わったことを検知
            if (nowPlayingFeedbackIndex >= feedbackTuples.Length)
            {
                onFinishCallback.Invoke();
                return;
            }
        }
        async UniTask PlayFeedbackAfterFewSeconds(float waitTime)
        {
            await UniTask.Delay(Mathf.RoundToInt(waitTime * 1000));
            PlayAfterNowIndex();
        }
    }


}