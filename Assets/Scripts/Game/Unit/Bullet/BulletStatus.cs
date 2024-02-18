using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatus : MonoBehaviour
{
    [SerializeField]float defaultAttackRatio;//ゲーム開始前から設定されている弾丸の攻撃力の割合
    float resultAttack;//プレイヤーの攻撃力などを反映して算出された最終的な攻撃力

    public void SettingAttack(float attack)
    {
        resultAttack = attack * defaultAttackRatio;
    }
}
