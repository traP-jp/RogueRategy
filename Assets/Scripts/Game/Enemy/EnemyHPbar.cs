using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyHPbar : MonoBehaviour
{
    private GameObject _currentHPbar;

    private EnemyManager _enemyManager;

    private SpriteRenderer _HPbarbase;
    private float _HPbarbasesize;
    
    // 現在HPの割合
    private float _currentHPratio;
    private Vector2 _currentHPbarPosition;
    private Vector2 _currentHPbarScale;
    
    void Awake()
    {
        // HPの実際の表示は子オブジェクトで
        _currentHPbar= transform.Find("CurrentHP").gameObject;
        // 親オブジェクトの敵を取得
        _enemyManager = transform.parent.gameObject.GetComponent<EnemyManager>();
        
        // 現在HPの反映
        _currentHPratio = (float)_enemyManager.nowHPProperty/(float)_enemyManager.maxHP;
        _currentHPbarPosition = new Vector2((_currentHPratio-1.0f)/2,0.0f);
        _currentHPbarScale = new Vector2(_currentHPratio,1.0f);
        _currentHPbar.transform.localPosition = _currentHPbarPosition;
        _currentHPbar.transform.localScale = _currentHPbarScale;

    }

    // Update is called once per frame
    public void HPBarUpdate()
    {
        // 現在HPの反映
        _currentHPratio = (float)_enemyManager.nowHPProperty/(float)_enemyManager.maxHP;
        _currentHPbarPosition = new Vector2((_currentHPratio-1.0f)/2,0.0f);
        _currentHPbarScale = new Vector2(_currentHPratio,1.0f);
        _currentHPbar.transform.localPosition = _currentHPbarPosition;
        _currentHPbar.transform.localScale = _currentHPbarScale;
    }

    public void Vanish()
    {
        Debug.Log("Destroy");
        Destroy(gameObject);

    }
}
