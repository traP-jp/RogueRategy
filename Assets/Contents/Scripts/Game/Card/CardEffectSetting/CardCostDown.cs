namespace Game.Card.CardEffectSetting
{
    [System.Serializable]
    public class CardCostDown : ICardEffectSetting
    {
        public int CardCount;
        public float CostRatio;
        public int DownAmount;
        public int MaxCost;
    }
}