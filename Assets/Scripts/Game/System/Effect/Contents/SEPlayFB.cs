using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Feedback
{
    [System.Serializable]
    public class SEPlayFB : IFeedback
    {
        public string SEName;
        public void Play(Vector2 position,Action onFinishedCallback)
        {
            SoundManager.Instance.PlaySE(SEName);
        }
    }
}