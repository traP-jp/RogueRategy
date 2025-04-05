using Game.Bullet.Movement;
using Game.Unit;
using UnityEngine;

namespace Game.Bullet
{
    public class BulletInitializerCircleSaw : MonoBehaviour, IBulletInitializer
    {
        Transform _playerTransform;
        
        public void Initialize(UnitStatus userStatus)
        {
            _playerTransform = userStatus.transform;
            foreach (var st in GetComponentsInChildren<BulletStatus>())
            {
                Debug.Log("SSS");
                st.AttackNormal = userStatus.AttackNow * st.AttackRatio;
                st.IsPlayerSide = userStatus.IsPlayerSide;
                st.gameObject.layer = userStatus.IsPlayerSide ? 7 : 9;
            }
        }

        public Transform GetPlayerTransform()
        {
            return _playerTransform;
        }
    }
}