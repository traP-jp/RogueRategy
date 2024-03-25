using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerStatus))]
public class PlayerManager : MonoBehaviour,IDamagable
{
    [SerializeField] float slowRate;
    [SerializeField] PlayerHPUpdater playerHPUpdater;

    [System.NonSerialized]public PlayerStatus playerStatus;
    [System.NonSerialized] public BuffStack playerBuffStack;

    private Rigidbody2D _rigidbody;

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
    private void Start()
    {
        playerHPUpdater.UpdateHPTank(Mathf.RoundToInt(playerStatus.HP));
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

        if (playerStatus.isControllReverse) realVelocity *= -1;
        _rigidbody.velocity = realVelocity;

        playerHPUpdater.UpdateHPTank(Mathf.RoundToInt(playerStatus.HP));
    }


    public void ChangePlayersHP(float changeHPAmount)
    {
        playerStatus.HP += changeHPAmount;
    }

    public void AddDamage(int strength)
    {
        ChangePlayersHP(strength);
    }
}
