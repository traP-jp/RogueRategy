using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerStatus))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] float slowRate;
    [SerializeField] int playerMaxHP;
    [SerializeField] PlayerHPUpdater playerHPUpdater;

    [System.NonSerialized]public PlayerStatus playerStatus;
    [System.NonSerialized] public BuffStack playerBuffStack;

    private Rigidbody2D _rigidbody;
    public int playerHPProperty
    {
        get
        {
            return playerHP;
        }
        set
        {
            if(value >= 0 && value <= playerMaxHP)
            {
                playerHP = value;
                playerHPUpdater.UpdateHPTank(value);
            }
            else
            {
                if (value < 0) playerHP = 0;
                if (value > playerMaxHP) playerHP = playerMaxHP;
                playerHPUpdater.UpdateHPTank(playerHP);
            }
        }
    }
    int playerHP;

    #region InputSystem関係
    GameInputs gameInputs;
    private void OnEnable()
    {
        gameInputs = new GameInputs();
        gameInputs.Enable();
    }
    private void OnDisable()
    {
        gameInputs.Disable();
    }
    #endregion

    private void Awake()
    {
        //自然な動きの実装(Rigidbody2Dの利用)
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        playerStatus = GetComponent<PlayerStatus>();
        playerBuffStack = GetComponent<BuffStack>();
    }
    void Start()
    {
        
        //プレイヤーHPの初期化(実際は常にHPMaxスタートではない)
        playerHPProperty = playerMaxHP-10;

    }
    // Update is called once per frame
    void Update()
    {
        float calculatedVelocity=playerStatus.resultSpeed;
        var realVelocity=new Vector2();
        if (gameInputs.BattleScene.Slow.IsPressed())
        {
            calculatedVelocity *= slowRate;
        }
        if (gameInputs.BattleScene.Up.IsPressed())
        {
            realVelocity.y += calculatedVelocity;
        }
        if (gameInputs.BattleScene.Down.IsPressed())
        {
            realVelocity.y -= calculatedVelocity;
        }       
        if (gameInputs.BattleScene.Left.IsPressed())
        {
            realVelocity.x -= calculatedVelocity;
        }
        if (gameInputs.BattleScene.Right.IsPressed())
        {
            realVelocity.x += calculatedVelocity;
        }

        _rigidbody.velocity = realVelocity;


    }
}
