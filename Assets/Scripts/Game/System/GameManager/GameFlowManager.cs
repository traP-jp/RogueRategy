using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameFlowManager : MonoBehaviour
{
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] CardManager cardManager;

    private void Start()
    {
        PlayerStatusInitialize();
        //他にもゲームを開始する処理や戦闘開始みたいな表示を出したりする時に使う
    }

    void PlayerStatusInitialize()
    {
        playerStatus.MaxHP = PlayersInfo.maxHP;
        playerStatus.HP = PlayersInfo.nowHP;
        playerStatus.attack = PlayersInfo.attack;
        playerStatus.defense = PlayersInfo.defense;
        playerStatus.speed = PlayersInfo.speed;
        playerStatus.bulletSpeed = PlayersInfo.bulletSpeed;
        //デッキも
        cardManager.SetNowDeck(PlayersInfo.playersDeck.ToArray());
    }


    public void OnBattleFinish()
    {
        //バトルが終了した時によぶ
        string sceneName = SceneManager.GetActiveScene().name.Replace("Battle", "Prepare");
        SceneManager.LoadScene(sceneName);
    }
}
