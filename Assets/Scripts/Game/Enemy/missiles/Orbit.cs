using UnityEngine;

public class FadeAndDestroy : MonoBehaviour
{
    public float fadeTime = 1.0f; // フェードアウト時間
    public GameObject childOrbit;
    private Material material;
    private Color originalColor;
    private float timer;
    void OnEnable()
    {
        if(material != null){
            // オブジェクトの色を更新
            Color color = originalColor;
            color.a = Mathf.Lerp(originalColor.a, 0, 0);
            material.color = color;
        }
    }

    void Start()
    {
        material = childOrbit.GetComponent<Renderer>().material;
        originalColor = material.color;
        OnEnable();
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        float ratio = Mathf.Clamp01(timer / fadeTime);

        // オブジェクトの色を更新
        Color color = originalColor;
        color.a = Mathf.Lerp(originalColor.a, 0, ratio);
        material.color = color;

        // 完全に透明になったらオブジェクト非アクティブに
        if (ratio == 1.0f)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
