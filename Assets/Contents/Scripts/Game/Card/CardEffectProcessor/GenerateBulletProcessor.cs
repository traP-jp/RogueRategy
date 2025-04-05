using System.Diagnostics;
using Game.Bullet;
using Game.Unit;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Game.Card.CardEffectProcessor
{
    public class GenerateBulletProcessor : MonoBehaviour
    {
        [SerializeField] Transform _bulletParent;
        public void Process(GameObject bulletPrefab, UnitStatus userStatus, Vector2 pos)
        {
            var initializer = Instantiate(bulletPrefab, pos, Quaternion.identity, _bulletParent).GetComponent<IBulletInitializer>();
            //userStatus.WeaponOrientation = userStatus.IsPlayerSide ? Vector2.right : Vector2.left;
            initializer.Initialize(userStatus);
        }
    }
}