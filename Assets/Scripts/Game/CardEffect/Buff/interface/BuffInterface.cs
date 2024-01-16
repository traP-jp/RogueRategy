using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect
{
    public interface IBuff
    {
        //バフにつける

    }
    public interface IBuffable
    {
        //バフを受けることができるキャラにつける
        void AddBuff(IBuff buff);
    }
}

