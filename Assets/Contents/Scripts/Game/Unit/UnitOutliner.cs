using SpriteGlow;
using UnityEngine;

namespace Game.Unit
{
    public class UnitOutliner : MonoBehaviour
    {
        [SerializeField] UnitStatus _status;

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