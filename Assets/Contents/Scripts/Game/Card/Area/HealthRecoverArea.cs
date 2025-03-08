using System;
using System.Collections.Generic;
using Game.Unit;
using UnityEngine;

namespace Game.Card.Area
{
    public class HealthRecoverArea : MonoBehaviour
    {
        public int RecoverAmount;
        public float RecoverInterval;
        public bool IsPlayerSideOnly;

        List<UnitStatus> _statusList = new List<UnitStatus>();

        float _nowTime = 0;

        void Start()
        {
            GetComponent<Collider2D>().enabled = true;
        }

        void Update()
        {
            _nowTime += Time.deltaTime;
            if (RecoverInterval < _nowTime)
            {
                foreach (var status in _statusList)
                {
                    status.HealthPoint.Value += RecoverAmount;
                }
                _nowTime -= RecoverInterval;
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Collision"))
            {
                var status = other.GetComponentInChildren<UnitStatus>();
                if (status.IsPlayerSide == IsPlayerSideOnly)
                {
                    _statusList.Add(status);   
                }
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Collision"))
            {
                var status = other.GetComponentInChildren<UnitStatus>();
                if (status.IsPlayerSide == IsPlayerSideOnly)
                {
                    _statusList.Remove(status);   
                }
            }
        }
    }
}