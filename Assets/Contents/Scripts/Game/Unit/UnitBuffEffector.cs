using System.Linq;
using UnityEngine;

namespace Game.Unit
{
    public class UnitBuffEffector : MonoBehaviour
    {
        [SerializeField] UnitStatus _status;

        void Update()
        {
            var buffStack = _status.GetBuffStack();
            foreach (var buff in buffStack.NowBuff.Where(b => b.BuffKind == BuffKind.AutoHealthRecover))
            {
                buff.IntervalTime -= Time.deltaTime;
                if (buff.IntervalTime < 0)
                {
                    buff.IntervalTime += float.Parse(buff.BuffInfos[1]);
                    _status.HealthPoint.Value += int.Parse(buff.BuffInfos[0]);
                }
            }
        }
    }
}