namespace Game.Card.CardEffectSetting
{
    [System.Serializable]
    public class HealthAutoRecoverArea : ICardEffectSetting
    {
        public int RecoveryAmount;
        public float RecoveryInterval;
    }
}