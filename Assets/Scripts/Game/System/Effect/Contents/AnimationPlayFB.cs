using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feedback
{
    [System.Serializable]
    public class AnimationPlayFB : IFeedback
    {
        [SerializeField] string animationName;
        public void Play(Vector2 position)
        {
            EffectDepictor.Instance.DepictEffect(position,animationName);
        }
    }
}

