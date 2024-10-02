using UnityEngine;

namespace Game.Unit
{
    [CreateAssetMenu(menuName = "ScriptableObject/UnitInfo")]
    public class UnitInfo : ScriptableObject
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _attack;
        public float MoveSpeed => _moveSpeed;
        public float Attack => _attack;
    }
}