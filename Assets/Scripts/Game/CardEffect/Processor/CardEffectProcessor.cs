using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectProcessor : SingletonMonoBehaviour<CardEffectProcessor>
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform playersUnitParentTransform;
    [SerializeField] Transform playerBulletParentTransform;
    [SerializeField] EnergyManager playerEnergy;
    PlayerManager playerManager;
    private void Start()
    {
        playerManager = playerTransform.GetComponent<PlayerManager>();
    }
    //カード効果を実行する役割を持つ
    public void GenerateUnitOnPlayer(UnitManager unitObject)
    {
       //ユニットを生成し、バフの引き継ぎを行う
        UnitManager unitManager = Instantiate(unitObject, playerTransform.position, Quaternion.identity, playersUnitParentTransform);
        //状態異常の引き継ぎ
        foreach (BuffCore bc in playerManager.playerBuffStack.GetNowBuffCoreArray())
        {
            if (bc.IsBuffSubjectOpponentUnit() || bc.IsBuffSubjectAllyUnit())
            {
                unitManager.unitBuffStack.AddBuff(bc);
            }
        }
    }

    public void RestoreEnergy(int amount)
    {
        playerEnergy.nowEnergyProperty += amount;
    }

    public void RecoverPlayerHP(int recoverHP)
    {
        playerManager.ChangePlayersHP(recoverHP);
    }

    public void GenerateBulletFromPlayer(BulletManager bulletObject)
    {
        //弾丸を生成する.　以前はGameObjectをInstantiateしていたが、BulletStatusに変更(GetComponentを減らすため)
        BulletManager bulletMane = Instantiate(bulletObject, playerTransform.position, Quaternion.identity, playerBulletParentTransform);
        bulletMane.bulletStatus.SettingAttack(playerManager.playerStatus.resultAttack);
        bulletMane.bulletMovement.Initialize(playerManager.playerStatus.resultBulletSpeed);
        //状態異常の引き継ぎ
        foreach(BuffCore bc in playerManager.playerBuffStack.GetNowBuffCoreArray())
        {
            if(bc.IsBuffSubjectOpponentUnit())
            {
                bulletMane.bulletsBuffList.Add(bc);
            }
        }
    }


}
