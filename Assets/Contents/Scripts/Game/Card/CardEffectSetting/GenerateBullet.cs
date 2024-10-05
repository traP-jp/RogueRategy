using Game.Bullet;

namespace Game.Card.CardEffectSetting
{
    [System.Serializable]
    public class GenerateBullet : ICardEffectSetting
    {
        public BulletInitializer BulletPrefab;
    }
}