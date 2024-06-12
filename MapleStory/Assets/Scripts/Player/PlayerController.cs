using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : Attribute
{
    //临时变量
   
    private IState currentState;
    private Dictionary<PlayerState, IState> states = new Dictionary<PlayerState, IState>();
    [Header("移动相关")]
    public float rightPressTime, leftPressTime;
    public float horizontalInput { get; private set; }   //玩家移动变量
    public float maxAwaitTime;  // 最大等待时间
    private bool moving, canRun;  // 是否在移动，是否可以奔跑
    [Header("跳跃相关")]
    public int jumpNum;
    //组件
    public Rigidbody2D _rb2D =>GetComponent<Rigidbody2D>();




    private void Start()
    {
        leftPressTime = rightPressTime = -maxAwaitTime;  // 初始化左右按下时间
        states.Add(PlayerState.Idle, new PlayerIdleState(this));
        states.Add(PlayerState.Move, new PlayerMoveState(this));
        states.Add(PlayerState.Jump, new PlayerJumpState(this));
        states.Add(PlayerState.Down, new PlayerDownState(this));
        TransitionState(PlayerState.Idle);
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
       
        currentState.OnUpdate();

    }

    private void FixedUpdate()
    {
        PlayerMove();
        currentState.OnFixUpdate();
    }
    public void TransitionState(PlayerState type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }

    


    public void PlayerMove()
    {
        // 计算移动方向
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
       CheckRun();
        // 移动角色
       transform.position += movement;
    }
    public void CheckRun()
    {
        if (horizontalInput == 1 && !moving)
        {
            if (Time.time - rightPressTime <= maxAwaitTime)
            {
                canRun = true;
            }
            rightPressTime = Time.time;
        }

        if (horizontalInput == -1 && !moving)
        {
            if (Time.time - leftPressTime <= maxAwaitTime)
            {
                canRun = true;
            }
            leftPressTime = Time.time;
        }

        // 取 h 的绝对值
        if (Mathf.Abs(horizontalInput) == 1)
        {
            moving = true;
            if (canRun)
            {
                moveSpeed = 8;
            }
            else
            {
                moveSpeed = 5;
            }
        }
        else
        {

            moving = false;
            canRun = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpNum = 2;
            TransitionState(PlayerState.Idle);
        }
    }
}
