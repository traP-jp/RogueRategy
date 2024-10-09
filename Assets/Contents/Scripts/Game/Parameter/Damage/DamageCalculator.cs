namespace Game.Parameter.Damage
{
    public static class DamageCalculator
    {
        public static int CalcDamage(int bulletAttack, int defence)
        {
            return bulletAttack - defence;
        }
    }
}