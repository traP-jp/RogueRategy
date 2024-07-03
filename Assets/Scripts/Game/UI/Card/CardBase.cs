using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CardInfo cardInfo;
    [SerializeField] private GameObject cardInfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCardInfo(CardInfo cardInfo){
        //ここにカードの情報を表示する処理を書く
        this.cardInfo = cardInfo;
        this.GetComponent<UnityEngine.UI.Image>().sprite = cardInfo.cardimage;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cardInfoPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardInfoPanel.SetActive(false);
    }

}
