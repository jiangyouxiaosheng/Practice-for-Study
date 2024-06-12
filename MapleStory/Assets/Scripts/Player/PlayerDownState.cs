using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDownState : IState
{
    public PlayerController playerManager;
    public PlayerDownState(PlayerController playerController)
    {
        playerManager = playerController;
    }
    public void OnEnter()
    {
        Debug.Log("½øÈëÏÂÂä×´Ì¬");
    }

    public void OnExit()
    {
       
    }

    public void OnFixUpdate()
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
    }
}
