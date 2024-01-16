using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect
{
    [System.Serializable]
    public class AddBuffToSomething : ICardEffect
    {
        IBuffable playerBuffManagement;//これになんとかして情報を与える
        [SerializeReference, SubclassSelector] IBuff buff;
        public void Process()
        {
            playerBuffManagement.AddBuff(buff);
        }
    }

}
