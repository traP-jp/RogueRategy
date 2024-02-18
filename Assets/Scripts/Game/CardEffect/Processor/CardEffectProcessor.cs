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
    public void GenerateUnitOnPlayer(GameObject unitObject)
    {
        Instantiate(unitObject, playerTransform.position, Quaternion.identity, playersUnitParentTransform);
    }

    public void RestoreEnergy(int amount)
    {
        playerEnergy.nowEnergyProperty += amount;
    }

    public void RecoverPlayerHP(int recoverHP)
    {
        playerManager.playerHPProperty += recoverHP;
    }

    public void GenerateBulletFromPlayer(BulletManager bulletObject)
    {
        //弾丸を生成する.　以前はGameObjectをInstantiateしていたが、BulletStatusに変更(GetComponentを減らすため)
        BulletManager bulletMane = Instantiate(bulletObject, playerTransform.position, Quaternion.identity, playerBulletParentTransform);
        bulletMane.bulletStatus.SettingAttack(playerManager.playerStatus.resultAttack);
        bulletMane.bulletMovement.SetupVelocity(5, 0);
        //状態異常の引き継ぎ
        BuffStack bulletBuffStack = bulletMane.buffStack;
        foreach(BuffCore bc in playerManager.playerBuffStack.GetNowBuffCoreArray())
        {
            if(bc.buffSubject is BuffSubjectEntity.Enemy or BuffSubjectEntity.EnemyAndPlayerUnit or BuffSubjectEntity.PlayerAndEnemy or BuffSubjectEntity.All)
            {
                bulletBuffStack.AddBuff(bc);
            }
        }
    }
}
