using Game.Unit;

namespace Game.Bullet
{
    public interface IBulletInitializer
    {
        public void Initialize(UnitStatus userStatus);
    }
}