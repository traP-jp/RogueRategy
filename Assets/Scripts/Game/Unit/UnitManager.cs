using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour,IDamagable
{
    //ユニットの各要素へのアクセスを統括する(バフ、移動、攻撃)
    public BuffStack unitBuffStack;
    public UnitStatus unitStatus;
    public bool isPlayerSide;//プレイヤーが出したユニットだったらこれをtrueにする。この情報を元に行動パターンなどを作る
    private void Reset()
    {
        unitBuffStack = GetComponent<BuffStack>();
        unitStatus = GetComponent<UnitStatus>();
    }

    public void ConveyBuffToBullet(BulletManager bulletManager)
    {
        foreach (BuffCore bc in unitBuffStack.GetNowBuffCoreArray())
        {
            if (bc.IsBuffSubjectOpponentUnit())
            {
                bulletManager.bulletsBuffList.Add(bc);
            }
        }
    }

    public void AddDamage(int strength)
    {
        unitStatus.HPChange(-strength);
        DrawHPbar();
    }


    //以下EnemyManagerから移したダメージ関係の処理
    [SerializeField] EnemyHPbar enemyHPbarPrehab;
    private EnemyHPbar _enemyHPbar;
    public bool HPbarDisplayed = false;
    private float _displaytime;
    private void Update()
    {
        if (!HPbarDisplayed) return;
        _displaytime -= Time.deltaTime;
        if (_displaytime >= 0f) return;
        VanishHPbar();
        HPbarDisplayed = false;

    }

    //HPバーの描画
    public void DrawHPbar()
    {
        if (!HPbarDisplayed && enemyHPbarPrehab != null)
        {
            _enemyHPbar = Instantiate(enemyHPbarPrehab, gameObject.transform);
            HPbarDisplayed = true;
        }
        else
        {
            _enemyHPbar.HPBarUpdate();
        }

        _displaytime = 3.0f;

    }

    //HPバーの消去

    public void VanishHPbar()
    {
        _enemyHPbar.Vanish();
        HPbarDisplayed = false;
    }

    public float GetHPRatio()
    {
       return unitStatus.HP / unitStatus.MaxHP;
    }

    public void ConveyBuff(BuffStack bulletsBuffStack)
    {
        //状態異常の引き継ぎ
        foreach (BuffCore bc in bulletsBuffStack.GetNowBuffCoreArray())
        {
            if (bc.IsBuffSubjectOpponentUnit())
            {
                bc.buffSubject = BuffSubjectEntity.MyselfButCantConvey;
                unitBuffStack.AddBuff(bc);
            }
        }
    }
}
