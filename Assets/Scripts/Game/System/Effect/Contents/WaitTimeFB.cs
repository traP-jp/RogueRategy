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
        public void Play(Vector2 position, Action onFinishCallback)
        {
            PlayFeedbackAfterFewSeconds(onFinishCallback).Forget();
        }
        async UniTask PlayFeedbackAfterFewSeconds(Action onFinishCallback)
        {
            await UniTask.Delay(Mathf.RoundToInt(waitTime * 1000));
            onFinishCallback.Invoke();
        }
    }
}

