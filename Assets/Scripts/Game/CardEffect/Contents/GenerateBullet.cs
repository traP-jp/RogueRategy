using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardEffect
{
    [System.Serializable]
    public class GenerateBullet : ICardEffect
    {
        [SerializeField] BulletManager bulletObject;
        [SerializeField] float magnification = 1;
        public void Process(StatusBase usersStatus,Vector2 usersPos)
        {
            CardEffectProcessor.Instance.GenerateBullet(bulletObject,usersStatus,usersPos, magnification);
        }
    }

}

