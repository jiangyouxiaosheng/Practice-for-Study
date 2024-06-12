using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerJumpState : IState
{
    public PlayerController playerManager;
    public PlayerJumpState(PlayerController playerController)
    {
        playerManager = playerController;
    }
    public void OnEnter()
    {
        Debug.Log("½øÈëÌøÔ¾×´Ì¬");
        playerManager._rb2D.AddForce(playerManager.transform.up * playerManager.jumpForce, ForceMode2D.Impulse);
    }

    public void OnExit()
    {
       
    }

    public void OnUpdate()
    {
       
        if (Input.GetKeyDown(KeyCode.K) && playerManager.jumpNum > 0)
        {
            playerManager._rb2D.velocity = Vector2.zero;
            playerManager.jumpNum--;
            playerManager._rb2D.AddForce(playerManager.transform.up * playerManager.jumpForce, ForceMode2D.Impulse);
        }
        if(playerManager._rb2D.velocity.y < 0)
        {
            playerManager.TransitionState(PlayerState.Down);
        }
        
    }
    public void OnFixUpdate()
    {

    }

 
}
