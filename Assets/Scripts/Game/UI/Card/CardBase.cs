using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class CardBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    private Animation animation;
    private CardInfo cardInfo;
    public float distanceY;
    public float percent;
    float startYposition;
    [SerializeField] private GameObject cardInfoPanel;
    [SerializeField] private TextMeshProUGUI explain;
    // Start is called before the first frame update
    bool animating = false;
    public bool showing = false;

    void Start()
    {
        startYposition = this.transform.localPosition.y;
        cardInfoPanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        percent = animator.GetFloat("Yposition");
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, startYposition + distanceY*percent, this.transform.localPosition.z);
    }
    public void SetCardInfo(CardInfo cardInfo){
        //ここにカードの情報を表示する処理を書く
        this.cardInfo = cardInfo;
        this.GetComponent<UnityEngine.UI.Image>().sprite = cardInfo.cardimage;
        explain.text = cardInfo.cardExplanation;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        cardInfoPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardInfoPanel.SetActive(false);
    }
    public void ShowthisCard(){

        CardPushAnimation();
    }   
    public void DrawthisCard(){
        
        CardPullAnimation();
    }
    public void CardPushAnimation()
    {
        if(animator == null){
            animator = GetComponent<Animator>();
            animation = GetComponent<Animation>();
        }
        animator.Play("CardShow");

    }
    public void CardPullAnimation(){
        if(animator == null){
            animator = GetComponent<Animator>();
            animation = GetComponent<Animation>();
        }
        animator.Play("CardDraw");
        Debug.Log("CardPullAnimation);");
    }
    
}