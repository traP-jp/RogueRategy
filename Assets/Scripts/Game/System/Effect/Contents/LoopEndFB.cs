using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feedback
{
    [System.Serializable]
    public class LoopEndFB : IFeedback
    {
        public int loopCount;
        public void Play(Vector2 position, Action<int> onFinishCallback, int feedbackParallelID = 0)
        {
            onFinishCallback(feedbackParallelID);
        }
    }
}

