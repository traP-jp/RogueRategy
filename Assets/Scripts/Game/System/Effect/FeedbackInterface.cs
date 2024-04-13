using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Feedback
{
    public interface IFeedback
    {
        void Play(Vector2 position,Action onFinishCallback);
    }
}

