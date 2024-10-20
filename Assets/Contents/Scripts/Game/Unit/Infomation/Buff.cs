using System;
using NaughtyAttributes;
using UnityEngine;

namespace Game.Unit
{
    [Serializable]
    public class Buff
    {
        [SerializeField] BuffKind _buffKind;
        [SerializeField] bool _buffOrDebuff;
        [SerializeField] string[] _buffInfos;
        [SerializeField] float _effectTime;
        
        public BuffKind BuffKind => _buffKind;
        public bool BuffOrDebuff => _buffOrDebuff;
        public string[] BuffInfos => _buffInfos;


        public float EffectTime => _effectTime;
        public float LeftTime { get; set; }
        
        public float IntervalTime { get; set; }//何秒かに一回発動する系のバフの次の発動までの時間を書く
        
    }

    public enum BuffKind
    {
        DamageReceiveRatio, //1...ダメージ受ける倍率(float)
        IncreaseAttack,  //1...攻撃力増加倍率(float)  2...攻撃力増加値(int)
        IncreaseDefence,  //1...防御力増加倍率(float)  2...防御力増加値(int)
        AutoHealthRecover,  //1...回復値(int)   2...回復間隔(float)
        Fired,  //1...ダメージ値(int)   2...ダメージ間隔(float)
        Iced  //1...スピード値減少割合
    }
}