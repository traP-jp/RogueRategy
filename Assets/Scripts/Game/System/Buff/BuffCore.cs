using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BuffCore
{
    //全てのバフはIBuffインターフェイスを廃止し、これを継承(諸事情によります)
    [SerializeReference, SubclassSelector] BuffTypeInspector.IBuffTypeInspector buffType;

    public BuffTypeInspector.IBuffTypeInspector GetBufftype()
    {
        return buffType;
    }
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
}
