using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feedback
{
    public class FeedbackManager : SingletonMonoBehaviour<FeedbackManager>
    {
        [System.Serializable]
        class OneFeedback
        {
            public string name;
            public Feedback feedback;
        }
        [SerializeField] OneFeedback[] feedbacks;
        Dictionary<string,Feedback> nameToFeedback;
        protected override void Awake()
        {
            base.Awake();
            nameToFeedback = new Dictionary<string, Feedback>();
            foreach(var oneFeedback in feedbacks)
            {
                nameToFeedback.Add(oneFeedback.name, oneFeedback.feedback);
            }
        }
        public void PlayFeedback(string feedbackName, Vector2 position)
        {   
            nameToFeedback[feedbackName].Play(position, () => { });
        }
    }
}