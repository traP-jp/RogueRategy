using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの頭上にUIを表示する時などカメラ座標のオブジェクトにUIを追従させるスクリプト
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class UITracker : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] Vector2 offset;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = (Vector2)Camera.main.WorldToScreenPoint(targetTransform.position) + offset;
    }
}
