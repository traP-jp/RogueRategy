using System.Collections;
using System.Collections.Generic;
using CardEffect;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class ItemGameInventory : MonoBehaviour
{
    #region InputSystem関係
    GameInputs gameInputs;
    private void OnEnable()
    {
        gameInputs = new GameInputs();
        gameInputs.BattleScene.UseItem1.performed += OnUseItem1;
        gameInputs.BattleScene.UseItem2.performed += OnUseItem2;
        gameInputs.BattleScene.UseItem3.performed += OnUseItem3;
        gameInputs.Enable();
    }
    private void OnDisable()
    {
        gameInputs.BattleScene.UseItem1.performed -= OnUseItem1;
        gameInputs.BattleScene.UseItem2.performed -= OnUseItem2;
        gameInputs.BattleScene.UseItem3.performed -= OnUseItem3;
        gameInputs.Disable();
    }
    #endregion

    PlayersInfo playersInfo;
    [SerializeField]Image[] itemImages;
    [SerializeField] PlayerStatus playerStatus;
    public void DepictItemInInventory(PlayersInfo _playersInfo)
    {
        playersInfo = _playersInfo;//このタイミングでPlayersInfoをGameFlowManagerから受け渡す
        for(int i = 0; i < itemImages.Length; i++)
        {
            itemImages[i].sprite = _playersInfo.playersItem[i]?.itemIcon;
        }
        
    }

    void OnUseItem1(InputAction.CallbackContext context)
    {
        OnUseItem(0);
    }
    void OnUseItem2(InputAction.CallbackContext context)
    {
        OnUseItem(1);
    }
    void OnUseItem3(InputAction.CallbackContext context)
    {
        OnUseItem(2);
    }
    void OnUseItem(int itemNumber)
    {
        if (playersInfo.playersItem[itemNumber] == null) return;
        Debug.Log("アイテム使用");
        //一旦アイテムを使用したときにカードを使用した時と同様の処理にする
        var bundle = playersInfo.playersItem[itemNumber].itemEffectInfo;
        if (playersInfo.playersItem[itemNumber].isUseItemOnPlayer)
        {
            CardUseProcessor.Instance.UseCard(bundle, playerStatus, playerStatus.transform.position);
        }
        else
        {
            CardUseProcessor.Instance.UseCard(bundle, playerStatus, Camera.main.ScreenToWorldPoint(Pointer.current.position.ReadValue()));
        }
        playersInfo.playersItem[itemNumber] = null;
        itemImages[itemNumber].sprite = null;
    }
}
