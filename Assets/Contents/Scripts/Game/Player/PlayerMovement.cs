using System;
using Game.Unit;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] UnitStatus _unitStatus;
        [SerializeField, Header("スロー時の速度")] float _slowRatio;
        
        
        #region インプット関係
        GameInputs _gameInputs;
        void OnEnable()
        {
            _gameInputs = new GameInputs();
            _gameInputs.Enable();
        }
        void OnDisable()
        {
            _gameInputs.Disable();
        }
        #endregion

        void Update()
        {
            float playerNowSpeed = _unitStatus.Speed;
            if (_gameInputs.BattleScene.Slow.IsPressed())
            {
                playerNowSpeed *= _slowRatio;
            }
            if (_gameInputs.BattleScene.Up.IsPressed())
            {
                transform.position += Vector3.up * (playerNowSpeed * Time.deltaTime);
            }
            if (_gameInputs.BattleScene.Down.IsPressed())
            {
                transform.position += Vector3.down * (playerNowSpeed * Time.deltaTime);
            }
            if (_gameInputs.BattleScene.Right.IsPressed())
            {
                transform.position += Vector3.right * (playerNowSpeed * Time.deltaTime);
            }
            if (_gameInputs.BattleScene.Left.IsPressed())
            {
                transform.position += Vector3.left * (playerNowSpeed * Time.deltaTime);
            }
        }
    }
}