using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardEffect
{
    [System.Serializable]
    public class GenerateBulletCircle : ICardEffect
    {
        [SerializeField] BulletManager bulletObject;
        [SerializeField] int bulletCount;
        public void Process(StatusBase usersStatus,Vector2 usersPos)
        {
            CardEffectProcessor.Instance.GenerateBulletCircle(bulletObject,usersStatus,usersPos, bulletCount);
        }
    }

}

