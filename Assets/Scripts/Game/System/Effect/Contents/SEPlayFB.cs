using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feedback
{
    [System.Serializable]
    public class SEPlayFB : IFeedback
    {
        public string SEName;
        public void Play(Vector2 position)
        {
            SoundManager.Instance.PlaySE(SEName);
        }
    }
}