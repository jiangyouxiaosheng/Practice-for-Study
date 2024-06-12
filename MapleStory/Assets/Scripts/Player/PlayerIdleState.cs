using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    public PlayerController playerManager;
    public PlayerIdleState (PlayerController playerController)
    {
        playerManager = playerController;
    }
    public void OnEnter()
    {
        Debug.Log("½øÈë´ý»ú×´Ì¬");
    }
    public void OnUpdate()
    {
        if (playerManager.horizontalInput != 0)
        {
            playerManager.TransitionState(PlayerState.Move);
        }
        if (Input.GetKeyDown(KeyCode.K) && playerManager.jumpNum > 0)
        {
            playerManager.TransitionState(PlayerState.Jump);
        }

    }
    public void OnExit()
    {
        
    }

    public void OnFixUpdate()
    {
        
    }
}
