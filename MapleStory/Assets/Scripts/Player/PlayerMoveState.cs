using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMoveState : IState
{
    public PlayerController playerManager;
 

    public PlayerMoveState(PlayerController playerController)
    {
        playerManager = playerController;
    }
    public void OnEnter()
    {
        Debug.Log("½øÈëÒÆ¶¯×´Ì¬");
    }
    public void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.K)&& playerManager.jumpNum>0) 
        {
            playerManager.jumpNum--;
            playerManager.TransitionState(PlayerState.Jump);
        }
        if(playerManager.horizontalInput == 0)
        {
            playerManager.TransitionState(PlayerState.Idle);
        }
    }
    public void OnExit()
    {
       
    }

    public void OnFixUpdate()
    {
      
        
    }
}
