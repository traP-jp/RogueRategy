namespace Game.Parameter.Damage
{
    public static class DamageCalculator
    {
        public static int CalcDamage(int userAttack, int bulletAttack, int defence)
        {
            return userAttack + bulletAttack - defence;
        }
    }
}