using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectProcessor : SingletonMonoBehaviour<CardEffectProcessor>
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform unitParentTransform;
    [SerializeField] Transform bulletParentTransform;
    [SerializeField] EnergyManager playerEnergy;
    PlayerManager playerManager;
    private void Start()
    {
        playerManager = playerTransform.GetComponent<PlayerManager>();
    }
    //カード効果を実行する役割を持つ
    public void GenerateUnit(UnitManager unitObject,StatusBase usersStatus,Vector2 usersPos)
    {
       //ユニットを生成し、バフの引き継ぎを行う
        UnitManager unitManager = Instantiate(unitObject, usersPos, Quaternion.identity, unitParentTransform);
        //状態異常の引き継ぎ
        foreach (BuffCore bc in usersStatus.connectedBuffStack.GetNowBuffCoreArray())
        {
            if (bc.IsBuffSubjectOpponentUnit() || bc.IsBuffSubjectAllyUnit())
            {
                unitManager.unitBuffStack.AddBuff(bc);
            }
        }
        //プレイヤー側のユニットかどうか判定
        unitManager.isPlayerSide = JudgeIsPlayerSide(usersStatus);
        //レイヤーの設定
        unitManager.gameObject.layer = unitManager.isPlayerSide ? 6 : 8;
    }

    public void RestoreEnergy(int amount)
    {
        playerEnergy.nowEnergyProperty += amount;
    }

    public void GenerateBullet(BulletManager bulletObject,StatusBase usersStatus,Vector2 usersPos)
    {
        //弾丸を生成する.　以前はGameObjectをInstantiateしていたが、BulletStatusに変更(GetComponentを減らすため)
        BulletManager bulletMane = Instantiate(bulletObject, usersPos, Quaternion.identity, bulletParentTransform);
        bulletMane.bulletStatus.SettingAttack(usersStatus.resultAttack);
        bulletMane.bulletMovement.Initialize(usersStatus.resultBulletSpeed);
        //状態異常の引き継ぎ
        foreach(BuffCore bc in usersStatus.connectedBuffStack.GetNowBuffCoreArray())
        {
            if(bc.IsBuffSubjectOpponentUnit())
            {
                bulletMane.bulletsBuffList.Add(bc);
            }
        }
        //レイヤーの設定
        bulletMane.gameObject.layer = JudgeIsPlayerSide(usersStatus) ? 7 : 9;
    }

    bool JudgeIsPlayerSide(StatusBase status)
    {
        //プレイヤーサイドのユニットorプレイヤーのステータスか判定
        bool isPlayerSide = false;
        if (status.GetType() == typeof(PlayerStatus)) isPlayerSide = true;
        if (status.GetType() == typeof(UnitStatus))
        {
            isPlayerSide = ((UnitStatus)status).unitManager.isPlayerSide;
        }
        return isPlayerSide;
    }
}
