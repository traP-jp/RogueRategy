using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Feedback
{
    [System.Serializable]
    public class WaitTimeFB : IFeedback
    {
        public float waitTime;
        public void Play(Vector2 position, Action<int> onFinishCallback,int parallelFeedbackID = -1)
        {
            PlayFeedbackAfterFewSeconds(onFinishCallback,parallelFeedbackID).Forget();
        }
        async UniTask PlayFeedbackAfterFewSeconds(Action<int> onFinishCallback,int parallelFeedbackID = -1)
        {
            await UniTask.Delay(Mathf.RoundToInt(waitTime * 1000));
            onFinishCallback.Invoke(parallelFeedbackID);
        }
    }
}

