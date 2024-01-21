using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect
{
    [System.Serializable]
    public class AddBuffToSomething : ICardEffect
    {
        [SerializeReference, SubclassSelector] BuffCore buff;
        public void Process()
        {
            //playerBuffManagement.AddBuff(buff);
            BuffManager.Instance.AddBuffToPlayer(buff);
        }
    }

}
