using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Unit
{
    public class UnitBuffStack : MonoBehaviour
    {
        [SerializeField] List<Buff> _nowBuff = new List<Buff>();
        public List<Buff> NowBuff => _nowBuff;
        
        void Update()
        {
            UpdateLeftTime();
        }

        void UpdateLeftTime()
        {
            foreach (var buff in _nowBuff)
            {
                buff.LeftTime -= Time.deltaTime;
            }
            _nowBuff = _nowBuff.Where(b => b.LeftTime > 0).ToList();
        }
    }
}