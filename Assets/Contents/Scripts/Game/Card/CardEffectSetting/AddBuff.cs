using Game.Unit;

namespace Game.Card.CardEffectSetting
{
    [System.Serializable]
    public class AddBuff : ICardEffectSetting
    {
        public Buff Buff;
    }
}