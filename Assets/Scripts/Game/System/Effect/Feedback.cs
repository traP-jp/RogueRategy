using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Feedback
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Feedback")]
    public class Feedback : ScriptableObject, IFeedback
    {
        [System.Serializable]
        class FeedbackTuple
        {
           [SerializeReference, SubclassSelector] public IFeedback mainFeedback;
           public bool isWaitForProcessEnd;
            public float intervalTime;
        }
        class FeedbackTuple2
        {
            public Feedback mainFeedback;
            public bool isWaitForProcessEnd;
            public float intervalTime;
        }
        [SerializeField] FeedbackTuple[] feedbackTuples;
        [SerializeField] Feedback[] childFeedbacks;
        public void Play(Vector2 position)
        {
            foreach(var tuple in feedbackTuples)
            {
                tuple.mainFeedback.Play(position);
            }
            foreach(var feedBack in childFeedbacks)
            {
                feedBack.Play(position);
            }
        }
    }
}