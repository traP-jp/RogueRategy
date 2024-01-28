using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : MonoBehaviour,IDamagable
{
    [SerializeField] UnityEngine.UI.Slider enemyHPSlider;
    int maxHP = 1000;
    int nowHP = 1000;
    int nowHPProperty
    {
        get { return nowHP; }
        set
        {
            if (value <= 0)
            {
                //エネミーを消す処理
            }
            else if (value > maxHP)
            {
                nowHP = maxHP;
                throw new System.ArgumentOutOfRangeException();
            }
            else nowHP = value;
        }
    }
   public void AddDamage(int strength)
    {
        try
        {
            nowHPProperty -= strength;
        }
        catch
        {

        }
        finally
        {
            //enemyHPSlider.value = nowHPProperty / (float)maxHP;
        }
    }
}
