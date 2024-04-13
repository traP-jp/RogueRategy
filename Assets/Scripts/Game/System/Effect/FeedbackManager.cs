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
        private void Awake()
        {
            nameToFeedback = new Dictionary<string, Feedback>();
            foreach(var oneFeedBack in feedbacks)
            {
                nameToFeedback.Add(oneFeedBack.name, oneFeedBack.feedback);
            }
        }
        public void PlayFeedback(string feedbackName, Vector2 position)
        {
            nameToFeedback[feedbackName].Play(position, () => { });
        }
    }
}