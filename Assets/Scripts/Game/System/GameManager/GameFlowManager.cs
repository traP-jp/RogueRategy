using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameFlowManager : MonoBehaviour
{
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] CardManager cardManager;
    [SerializeField] PlayersInfo playersInfo;
    [SerializeField] ItemGameInventory itemGameInventory;

    //このボスが死んだ時ゲーム終了とする
    [SerializeField] UnitStatus bossStatus;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject gameOverScreen;
    private void Awake()
    {
        PlayerStatusInitialize();
        //他にもゲームを開始する処理や戦闘開始みたいな表示を出したりする時に使う
        //ゲーム開始時に持っているアイテムに応じてアイテムインベントリーの更新を行う処理
        //itemGameInventory.DepictItemInInventory(playersInfo);
    }

    private void Update()
    {
        //仮置き、ボスが死んだらカードを選択する画面が出て準備シーンに戻る
        if(bossStatus.HP <= 0)
        {
            OnBattleFinish();
        }
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

    public void TransitionScene()
    {
        //バトルが終了し、報酬(カード)を選択した後に呼ぶ
        playersInfo.nowHP = playerStatus.HP;
        string sceneName = SceneManager.GetActiveScene().name.Replace("Battle", "Prepare");
        SceneManager.LoadScene(sceneName);
    }
    public void OnBattleFinish()
    {
        //バトルが終了した時によぶ
        victoryScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
