using UnityEngine;

namespace Game.Unit
{
    public class UnitStatus : MonoBehaviour
    {
        [SerializeField] float _speed;
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
    }
}