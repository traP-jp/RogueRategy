using UnityEngine;
public class MyComponent : MonoBehaviour
{
    //テスト用
    private void Start()
    {
        //SoundManager.Instance.PlaySE("TEST", () => { });
        Feedback.FeedbackManager.Instance.PlayFeedback("Test",Vector2.zero);
    }
}

