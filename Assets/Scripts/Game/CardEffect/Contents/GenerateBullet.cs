using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardEffect
{
    [System.Serializable]
    public class GenerateBullet : ICardEffect
    {
        [SerializeField] GameObject bulletObject;
        public void Process()
        {
            CardEffectProcessor.Instance.GenerateBulletFromPlayer(bulletObject);
        }
    }

}

