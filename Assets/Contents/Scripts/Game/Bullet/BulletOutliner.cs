using Game.Unit;
using SpriteGlow;
using UnityEngine;

namespace Game.Bullet
{
    public class BulletOutliner : MonoBehaviour
    {
        [SerializeField] BulletStatus _status;

        void Start()
        {
            var effect = gameObject.AddComponent<SpriteGlowEffect>();
            effect.GlowColor = !_status.IsPlayerSide ? new Color(0, 0.137f, 1) : new Color(1, 0.03f, 0);
            effect.GlowBrightness = 2;
            effect.OutlineWidth = 1;
            effect.DrawOutside = true;
        }
    }
}