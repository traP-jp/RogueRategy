using System.Collections.Generic;
using Game.Unit;
using UnityEngine;
using Utility.Extension;

namespace Game.Card.Area
{
    public class HealthRecoverArea : MonoBehaviour
    {
        public int RecoverAmount;
        public float RecoverInterval;
        public bool IsPlayerSideOnly;
        public float Radius;
        public int LeftRecoverCount;
        
        float _nowTime = 0;

        void Start()
        {
            GetComponent<Collider2D>().enabled = true;
            transform.SetLossyScale(new Vector3(Radius / 0.4f,Radius/ 0.4f, Radius/ 0.4f));
        }

        void FixedUpdate()
        {
            _nowTime += Time.deltaTime;
            
            List<UnitStatus> statusList = new List<UnitStatus>();
            var colliders = Physics2D.OverlapCircleAll(transform.position, Radius);
            foreach (var col in colliders)
            {
                if (col.CompareTag("Collision"))
                {
                    statusList.Add(col.GetComponentInChildren<UnitStatus>());
                }
            }
            
            if (RecoverInterval < _nowTime)
            {
                LeftRecoverCount--;
                foreach (var status in statusList)
                {
                    status.HealthPoint.Value += RecoverAmount;
                }
                _nowTime -= RecoverInterval;
                if (LeftRecoverCount < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}