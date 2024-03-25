using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
public class EnemyManager : MonoBehaviour,IDamagable
{
    [SerializeField] EnemyHPbar enemyHPbarPrehab;
    private EnemyHPbar _enemyHPbar;
    public bool HPbarDisplayed = false;
    
    public int maxHP = 1000;
    public int nowHP = 1000;
    private float _displaytime;
    
    public int nowHPProperty
    {
        get { return nowHP; }
        set
        {
            if (value <= 0)
            {
                nowHP = 0;
                //エネミーを消す処理
            }
            else if (value > maxHP)
            {
                nowHP = maxHP;
            }
            else nowHP = value;
        }
    }
    

    private void Update()
    {
        if (!HPbarDisplayed) return;
        _displaytime -= Time.deltaTime;
        if (_displaytime >= 0f) return; 
        VanishHPbar(); 
        HPbarDisplayed = false;
        
    }

    public void AddDamage(int strength)
    {
        nowHPProperty -= strength;
        DrawHPbar();
    }

   //HPバーの描画
   public void DrawHPbar()
   {
       if (!HPbarDisplayed)
       {
           _enemyHPbar=Instantiate(enemyHPbarPrehab,gameObject.transform);
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
}
