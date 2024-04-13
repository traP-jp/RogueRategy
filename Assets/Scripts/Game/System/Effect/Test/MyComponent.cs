using UnityEngine;

public enum MyEnum
{
    Option1,
    Option2,
    Option3
}

public class MyComponent : MonoBehaviour
{
    private void Start()
    {
        //SoundManager.Instance.PlaySE("TEST", () => { });
    }
    public MyEnum enumValue;
}

