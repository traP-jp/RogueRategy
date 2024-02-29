using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameFlowManager : MonoBehaviour
{
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] CardManager cardManager;
    [SerializeField] PlayersInfo playersInfo;
    private void Awake()
    {
        PlayerStatusInitialize();
        //他にもゲームを開始する処理や戦闘開始みたいな表示を出したりする時に使う
    }

    void PlayerStatusInitialize()
    {
        playerStatus.MaxHP = playersInfo.maxHP;
        playerStatus.HP = playersInfo.nowHP;
        playerStatus.attack = playersInfo.attack;
        playerStatus.defense = playersInfo.defense;
        playerStatus.speed = playersInfo.speed;
        playerStatus.bulletSpeed = playersInfo.bulletSpeed;
        //デッキも
        cardManager.SetNowDeck(playersInfo.playersDeck.ToArray());
        
    }


    public void OnBattleFinish()
    {
        //バトルが終了した時によぶ
        string sceneName = SceneManager.GetActiveScene().name.Replace("Battle", "Prepare");
        SceneManager.LoadScene(sceneName);
    }
}
