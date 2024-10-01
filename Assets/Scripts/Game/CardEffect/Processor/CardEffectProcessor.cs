using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectProcessor : SingletonMonoBehaviour<CardEffectProcessor>
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform playersUnitParentTransform;
    [SerializeField] Transform enemysUnitParentTransform;
    
    [SerializeField] EnergyManager playerEnergy;
    PlayerManager playerManager;
    private void Start()
    {
        playerManager = playerTransform.GetComponent<PlayerManager>();
    }
    //カード効果を実行する役割を持つ
    public void GenerateUnit(UnitManager unitObject,StatusBase usersStatus,Vector2 usersPos)
    {
        bool _isPlayerSide = JudgeIsPlayerSide(usersStatus);
        //ユニットを生成し、バフの引き継ぎを行う

        UnitManager unitManager = Instantiate(unitObject, usersPos, Quaternion.identity, _isPlayerSide ? playersUnitParentTransform : enemysUnitParentTransform);
        //状態異常の引き継ぎ
        foreach (BuffCore bc in usersStatus.connectedBuffStack.GetNowBuffCoreArray())
        {
            if ((bc.IsBuffSubjectOpponentUnit() && bc.buffSubject != BuffSubjectEntity.OpponentUnitButOnlyViaSelfBullet) || bc.IsBuffSubjectAllyUnit())
            {
                unitManager.unitBuffStack.AddBuff(bc);
            }
        }
        //プレイヤー側のユニットかどうか判定
        unitManager.isPlayerSide = _isPlayerSide;
        //レイヤーの設定
        unitManager.gameObject.layer = unitManager.isPlayerSide ? 6 : 8;
    }

    public void RestoreEnergy(int amount)
    {
        playerEnergy.ChangeEnergyValue(amount);
    }
}
