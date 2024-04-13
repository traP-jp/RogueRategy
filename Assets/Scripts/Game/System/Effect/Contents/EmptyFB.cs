using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Feedback
{
    [System.Serializable]
    public class EmptyFB : IFeedback
    {
        public void Play(Vector2 position,Action onFinishedCallback)
        {
        }
    }
}
