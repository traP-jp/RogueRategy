using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DestinationViewUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    RectTransform _rectTransform;
    [SerializeField] float _moveTime;
    [SerializeField] Vector3 _cardPosition;
    [SerializeField] Vector3 _useCardPosition;
    [SerializeField] Vector3 _useCardPosition2;
    [SerializeField] Vector3 _cleanCardPosition;

    public void SetCardView(Sprite sprite){
        _rectTransform = GetComponent<RectTransform>();
        this.GetComponent<Image>().sprite = sprite;
        //カードを上に動かす
        _rectTransform.DOAnchorPos(_cardPosition, _moveTime).SetEase(Ease.OutExpo)
        .SetRelative(true);

    }

    public void UseThisCardAnimation(){
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rectTransform.DOAnchorPos(_useCardPosition, _moveTime).SetEase(Ease.OutExpo));
        sequence.Append(_rectTransform.DOAnchorPos(_useCardPosition2, _moveTime).SetEase(Ease.OutExpo).SetRelative(true));
        
    }

    public void CleanThisCardAnimation(){
        //カードを下に動かす
        _rectTransform.DOAnchorPos(_cleanCardPosition, _moveTime).SetEase(Ease.OutExpo).SetRelative(true);
    }
    //選択されているときにDotweenでカードを大きくする
    public void ChooseCard(){
        _rectTransform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), _moveTime).SetEase(Ease.OutExpo);
    }
    //選択されていないときにDotweenでカードを元に戻す
    public void UnChooseCard(){
        _rectTransform.DOScale(new Vector3(1f, 1f, 1f), _moveTime).SetEase(Ease.OutExpo);
    }
    void OnDestroy(){
        DOTween.Kill(this.gameObject);
    }
}
