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
    int nowHP = 100;
    private float _displaytime;
    
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

    void Start()
    {
        DrawHPbar();
        
    }

    private void Update()
    {
        if (!HPbarDisplayed) return;
        _displaytime -= Time.deltaTime;
        Debug.Log(_displaytime);
        if (_displaytime >= 0f) return; 
        VanishHPbar(); 
        HPbarDisplayed = false;
        
    }

    public void AddDamage(int strength)
    {
        try
        {
            nowHPProperty -= strength;
            DrawHPbar();
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
