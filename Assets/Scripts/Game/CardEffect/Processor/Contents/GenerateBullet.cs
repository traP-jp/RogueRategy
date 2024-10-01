using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardEffect
{
    public class GenerateBulletProcessor : MonoBehaviour, ICardEffectProcessor
    {
        [SerializeField] BulletManager bulletObject;
        [SerializeField] float magnification = 1;
        [SerializeField] Transform bulletParentTransform;
        
        public void Process(StatusBase usersStatus,Vector2 usersPos)
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
        
        bool JudgeIsPlayerSide(StatusBase status)
        {
            //プレイヤーサイドのユニットorプレイヤーのステータスか判定
            bool isPlayerSide = status.GetType() == typeof(PlayerStatus);
            if (status.GetType() == typeof(UnitStatus))
            {
                isPlayerSide = ((UnitStatus)status).unitManager.isPlayerSide;
            }
            return isPlayerSide;
        }
    }

}

