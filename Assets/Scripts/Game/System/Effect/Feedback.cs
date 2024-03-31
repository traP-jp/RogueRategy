using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Feedback
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Feedback")]
    public class Feedback : ScriptableObject, IFeedback
    {
        [SerializeReference, SubclassSelector] IFeedback mainFeedback;
        [SerializeField] Feedback[] childFeedbacks;
        public void Play(Vector2 position)
        {
            mainFeedback.Play(position);
            foreach(var feedBack in childFeedbacks)
            {
                feedBack.Play(position);
            }
        }
    }
}