using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : MonoBehaviour,IDamagable
{
    [SerializeField] EnemyHPbar enemyHPbar;
    public bool HPbarDisplayed = false;
    
    public int maxHP = 1000;
    int nowHP = 1000;
    public int nowHPProperty
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

   //HPバーの描画
   public void DrawHPbar()
   {
       
   }
   
   //HPバーの消去
}
