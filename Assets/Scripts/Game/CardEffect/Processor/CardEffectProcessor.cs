using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectProcessor : SingletonMonoBehaviour<CardEffectProcessor>
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform playersUnitParentTransform;
    [SerializeField] Transform enemysUnitParentTransform;
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

    public void GenerateBullet(BulletManager bulletObject,StatusBase usersStatus,Vector2 usersPos,float magnification)
    {
        //弾丸を生成する.　以前はGameObjectをInstantiateしていたが、BulletStatusに変更(GetComponentを減らすため)
        BulletManager bulletMane = Instantiate(bulletObject, usersPos, Quaternion.identity, bulletParentTransform);
        bulletMane.bulletStatus.SettingAttack(usersStatus.resultAttack);
        bulletMane.bulletMovement.Initialize(usersStatus.resultBulletSpeed,JudgeIsPlayerSide(usersStatus));
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
        
        //サイズの設定
        Vector3 bulletManeLocalScale = bulletMane.transform.localScale;
        bulletMane.transform.localScale = new Vector3(magnification * bulletManeLocalScale.x, magnification * bulletManeLocalScale.y, 0);
    }

    public void GenerateBulletCircle(BulletManager bulletObject, StatusBase usersStatus, Vector2 usersPos, int bulletCount, float magnification)
    {
        //bulletCount...輪状に弾幕を飛ばすのの一周の弾幕の数
        float deltaDegree = 360f / (float)bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            //弾丸を生成する.　以前はGameObjectをInstantiateしていたが、BulletStatusに変更(GetComponentを減らすため)
            BulletManager bulletMane = Instantiate(bulletObject, usersPos, Quaternion.identity, bulletParentTransform);
            bulletMane.bulletStatus.SettingAttack(usersStatus.resultAttack);
            bulletMane.transform.rotation = Quaternion.Euler(new Vector3(0, 0, deltaDegree * i));
            bulletMane.bulletMovement.Initialize(usersStatus.resultBulletSpeed, JudgeIsPlayerSide(usersStatus));
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
            
            //サイズの設定
            Vector3 bulletManeLocalScale = bulletMane.transform.localScale;
            bulletMane.transform.localScale = new Vector3(magnification * bulletManeLocalScale.x, magnification * bulletManeLocalScale.y, 0);
        }
        
        
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
