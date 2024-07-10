using UnityEngine;
using Feedback;
namespace CardEffect
{
    [System.Serializable]
    public class DoFeedback : ICardEffect
    {
        enum FeedbackKind
        {
            SelfMadeFeedback,
            ChangeableFeedback
        }
        [System.Serializable]
        class FeedbackTuple
        {
            public FeedbackKind feedbackKind;
            public Feedback.Feedback selfMadeFB;
            [SerializeReference, SubclassSelector] public IFeedback changeableFB;
        }

        [SerializeField] FeedbackTuple _feedback;
        public void Process(StatusBase usersStatus, Vector2 usersPos)
        {
            if (_feedback.feedbackKind == FeedbackKind.SelfMadeFeedback)
            {
                _feedback.selfMadeFB.Play(usersPos, _ => {});
            }
            else
            {
                _feedback.changeableFB.Play(usersPos, _=>{});
            }
        }
    }
}