using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect
{
    public interface IBuffable
    {
        //バフを受けることができるキャラにつける
        void AddBuff(BuffCore buff);

        void RemoveBuff(BuffCore buff);
    }
}

