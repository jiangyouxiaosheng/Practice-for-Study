using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public bool ��ת״̬;

    public float ��ת�ٶ�;
    public bool ��ס;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ��ת״̬ = !��ת״̬;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ��ס = true;
        }
        else
        {
            ��ס = false;
        }

        if (��ת״̬)
        {
            if (transform.rotation.eulerAngles.x < (��ס ? 90 : 180))
            {
                transform.Rotate(new Vector3((Time.deltaTime * ��ת�ٶ�), 0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler((��ס ? 90 : 180), 0, 0);
            }
        }
        else
        {
            if (transform.rotation.x > (��ס ? 90 : 0))
            {
                transform.Rotate(new Vector3(-(Time.deltaTime * ��ת�ٶ�), 0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler((��ס ? 90 : 0), 0, 0);
            }
        }
    }

  
}
