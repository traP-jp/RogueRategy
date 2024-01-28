using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BuffCore
{
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
    public abstract void Process();
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
