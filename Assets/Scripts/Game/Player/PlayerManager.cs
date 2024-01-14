using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] float playerVelocity;


    #region InputSystem関係
    GameInputs gameInputs;
    private void OnEnable()
    {
        gameInputs = new GameInputs();
        gameInputs.Enable();
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameInputs.BattleScene.Up.IsPressed())
        {
            transform.position = Vector2.up * playerVelocity * Time.deltaTime + (Vector2)transform.position;
        }
        if (gameInputs.BattleScene.Down.IsPressed())
        {
            transform.position = Vector2.down * playerVelocity * Time.deltaTime + (Vector2)transform.position;
        }       
        if (gameInputs.BattleScene.Left.IsPressed())
        {
            transform.position = Vector2.left * playerVelocity * Time.deltaTime + (Vector2)transform.position;
        }
        if (gameInputs.BattleScene.Right.IsPressed())
        {
            transform.position = Vector2.right * playerVelocity * Time.deltaTime + (Vector2)transform.position;
        }

        
    }
}
