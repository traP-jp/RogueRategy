using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BuffCore
{
    //BuffCoreから派生する各バフはプレイヤーのみしか適用されないやつなど(CostChange.cs)などがあり、判定する方法がないため変数だけ作っておきます
    public BuffSubjectEntity buffSubject;//実装はまだ

    //全てのバフはIBuffインターフェイスを廃止し、これを継承(諸事情によります)
    [SerializeReference, SubclassSelector] BuffTypeInspector.IBuffTypeInspector buffType;
    [SerializeReference, SubclassSelector] BuffTypeInspector.IBuffTypeWhenActivate buffTypeWhenActivate;
    public BuffTypeInspector.IBuffTypeInspector GetBufftype()
    {
        return buffType;
    }
    public BuffTypeInspector.IBuffTypeWhenActivate GetBuffWhenActivate()
    {
        return buffTypeWhenActivate;
    }
    public abstract void Process(StatusBase statusBase);

    public bool IsBuffSubjectPlayer()
    {
        return buffSubject is BuffSubjectEntity.Player or BuffSubjectEntity.PlayerAndAllyUnit or BuffSubjectEntity.PlayerAndOpponentUnit or BuffSubjectEntity.All;
    }
    public bool IsBuffSubjectAllyUnit()
    {
        return buffSubject is BuffSubjectEntity.AllyUnit or BuffSubjectEntity.PlayerAndAllyUnit or BuffSubjectEntity.OpponentUnitAndAllyUnit or BuffSubjectEntity.All;
    }
    public bool IsBuffSubjectOpponentUnit()
    {
        return buffSubject is BuffSubjectEntity.OpponentUnit or BuffSubjectEntity.OpponentUnitAndAllyUnit or BuffSubjectEntity.PlayerAndOpponentUnit or BuffSubjectEntity.All;
    }
}
public enum BuffSubjectEntity
{
    OpponentUnit,
    Player,
    AllyUnit,
    PlayerAndAllyUnit,
    OpponentUnitAndAllyUnit,
    PlayerAndOpponentUnit,
    All,
    MyselfButCantConvey //自分はバフの効果を受けるがそれ以外のものに伝達することはない
}

namespace BuffTypeInspector
{
    //ここ専用のネームスペース
    public interface IBuffTypeInspector { };
    [System.Serializable]
    public class LimitedTime : IBuffTypeInspector
    {
        public float durationTime;
    }
    [System.Serializable]
    public class LimitedCardCount : IBuffTypeInspector
    {
        public int limitCardCount;
    }
    [System.Serializable]
    public class Permanent : IBuffTypeInspector
    {
    }



    public interface IBuffTypeWhenActivate { }
    [System.Serializable]
    public class OnCardUse:IBuffTypeWhenActivate
    {
    }
    [System.Serializable]
    public class AtInterval:IBuffTypeWhenActivate
    {
       public float intervalTime;
    }
    [System.Serializable]
    public class Permanently : IBuffTypeWhenActivate { }
}
