using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : Attribute
{
    //��ʱ����
   
    private IState currentState;
    private Dictionary<PlayerState, IState> states = new Dictionary<PlayerState, IState>();
    [Header("�ƶ����")]
    public float rightPressTime, leftPressTime;
    public float horizontalInput { get; private set; }   //����ƶ�����
    public float maxAwaitTime;  // ���ȴ�ʱ��
    private bool moving, canRun;  // �Ƿ����ƶ����Ƿ���Ա���
    [Header("��Ծ���")]
    public int jumpNum;
    //���
    public Rigidbody2D _rb2D =>GetComponent<Rigidbody2D>();




    private void Start()
    {
        leftPressTime = rightPressTime = -maxAwaitTime;  // ��ʼ�����Ұ���ʱ��
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
        // �����ƶ�����
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
       CheckRun();
        // �ƶ���ɫ
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

        // ȡ h �ľ���ֵ
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
