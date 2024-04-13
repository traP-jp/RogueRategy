using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Feedback
{
    [System.Serializable]
    public class AnimationPlayFB : IFeedback
    {
        [SerializeField] string animationName;
        public void Play(Vector2 position, Action onFinishedCallback)
        {
            EffectDepictor.Instance.DepictEffect(position,animationName);
            onFinishedCallback.Invoke();
        }
    }
}

