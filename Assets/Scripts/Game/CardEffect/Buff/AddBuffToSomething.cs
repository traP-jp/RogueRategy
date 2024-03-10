using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect
{
    [System.Serializable]
    public class AddBuffToSomething : ICardEffect
    {
        [SerializeReference, SubclassSelector] BuffCore buff;
        public void Process(StatusBase usersStatus,Vector2 usersPos)
        {
            usersStatus.connectedBuffStack.AddBuff(buff);
        }
    }

}
