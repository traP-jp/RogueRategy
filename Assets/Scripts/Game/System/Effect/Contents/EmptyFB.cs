using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feedback
{
    [System.Serializable]
    public class EmptyFB : IFeedback
    {
        public void Play(Vector2 position)
        {
        }
    }
}
