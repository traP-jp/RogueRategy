using System.Diagnostics;
using Game.Bullet;
using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class GenerateBulletProcessor : MonoBehaviour
    {
        [SerializeField] Transform _bulletParent;
        public void Process(BulletInitializer bulletPrefab, UnitStatus userStatus, Vector2 pos)
        {
            BulletInitializer initializer = Instantiate(bulletPrefab, pos, Quaternion.identity, _bulletParent);
            initializer.Initialize(userStatus, userStatus.IsPlayerSide ? Vector2.right : Vector2.left);
        }
    }
}