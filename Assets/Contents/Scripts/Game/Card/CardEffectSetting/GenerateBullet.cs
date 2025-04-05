using Game.Bullet;
using UnityEngine;

namespace Game.Card.CardEffectSetting
{
    [System.Serializable]
    public class GenerateBullet : ICardEffectSetting
    {
        public GameObject BulletPrefab;
    }
}