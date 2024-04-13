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
            public Feedback selfMadeFeedback;
           [SerializeReference, SubclassSelector] public IFeedback changeableFeedback;
           public bool isWaitForEnd;
            public float intervalTime;
        }
        [SerializeField] FeedbackTuple[] feedbackTuples;
        int nowPlayingFeedbackIndex = 0;//今再生しているのはfeedbackTuples[nowPlayingFeedbackIndex]
        Vector2 nowPlayingFeedbackPosition;//今再生しているフィードバックの座標
        public void Play(Vector2 position,Action onFinishedCallback)
        {
            nowPlayingFeedbackIndex = 0;
            nowPlayingFeedbackPosition = position;
            PlayAfterNowIndex();
        }

        void PlayAfterNowIndex()
        {
            //今のindex番目以降のフィードバックを再生
            for(;nowPlayingFeedbackIndex < feedbackTuples.Length;)
            {
                var feedbackTuple = feedbackTuples[nowPlayingFeedbackIndex];
                nowPlayingFeedbackIndex++;
                if (feedbackTuple.feedbackKind == FeedbackKind.SelfMadeFeedback)
                {
                    if (feedbackTuple.isWaitForEnd)
                    {
                        feedbackTuple.selfMadeFeedback.Play(nowPlayingFeedbackPosition, PlayAfterNowIndex);
                    }
                    else if(feedbackTuple.intervalTime != 0)
                    {
                        feedbackTuple.selfMadeFeedback.Play(nowPlayingFeedbackPosition, () => { });
                        PlayFeedbackAfterFewSeconds(feedbackTuple.intervalTime).Forget();
                    }
                    else
                    {
                        feedbackTuple.selfMadeFeedback.Play(nowPlayingFeedbackPosition, () => { });
                    }

                }
                else
                {
                    if (feedbackTuple.isWaitForEnd)
                    {
                        feedbackTuple.changeableFeedback.Play(nowPlayingFeedbackPosition, PlayAfterNowIndex);
                    }
                    else if (feedbackTuple.intervalTime != 0)
                    {
                        feedbackTuple.changeableFeedback.Play(nowPlayingFeedbackPosition, () => { });
                        PlayFeedbackAfterFewSeconds(feedbackTuple.intervalTime).Forget();
                    }
                    else
                    {
                        feedbackTuple.changeableFeedback.Play(nowPlayingFeedbackPosition, () => { });
                    }
                }
            }
        }
        async UniTask PlayFeedbackAfterFewSeconds(float waitTime)
        {
            await UniTask.Delay(Mathf.RoundToInt(waitTime * 1000));
            PlayAfterNowIndex();
        }
    }


}