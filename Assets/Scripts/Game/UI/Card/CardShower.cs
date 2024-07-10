using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShower : MonoBehaviour
{
    [SerializeField] private PlayersInfo playerInfo;
    [SerializeField] private List<GameObject> cardbases;
    //プレハブ
    [SerializeField] private GameObject cardbase;
    private int nowpage = 0;
    private int eachpage = 5;
    // Start is called before the first frame update
    void Start()
    {
        ShowAllCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAllCard(){
        foreach(CardInfo card in playerInfo.playersDeck){
            GameObject onecardbase = Instantiate(cardbase);
            onecardbase.transform.SetParent(this.transform);
            onecardbase.GetComponent<CardBase>().SetCardInfo(card);
            cardbases.Add(onecardbase);
            
        }
        LayoutCards();
        NowShowCard();
    }
    public void LayoutCards(){
        for(int i = 0; i < cardbases.Count; i++){
            int point = i % eachpage;
            cardbases[i].transform.localPosition = new Vector3(point*100 - 250, -20,0);
        }
    }
    public void NowShowCard(){
        foreach(GameObject cardbase in cardbases){
            if(cardbase.GetComponent<CardBase>().showing == true){
                cardbase.GetComponent<CardBase>().DrawthisCard();
                cardbase.GetComponent<CardBase>().showing = false;
            }
            
        }
        for(int i = nowpage*eachpage; i < Mathf.Min(nowpage*eachpage + eachpage, cardbases.Count); i++){
            Debug.Log(i);
            cardbases[i].GetComponent<CardBase>().ShowthisCard();
            cardbases[i].GetComponent<CardBase>().showing = true;
        }
    }
    public void NextPage(){
        if(nowpage < cardbases.Count/eachpage){
            nowpage++;
            NowShowCard();
        }
    }
    public void BackPage(){
        if(nowpage > 0){
            nowpage--;
            NowShowCard();
        }
    }
}
