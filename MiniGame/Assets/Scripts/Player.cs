using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public bool 旋转状态;

    public float 旋转速度;
    public bool 按住;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            旋转状态 = !旋转状态;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            按住 = true;
        }
        else
        {
            按住 = false;
        }

        if (旋转状态)
        {
            if (transform.rotation.eulerAngles.x < (按住 ? 90 : 180))
            {
                transform.Rotate(new Vector3((Time.deltaTime * 旋转速度), 0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler((按住 ? 90 : 180), 0, 0);
            }
        }
        else
        {
            if (transform.rotation.x > (按住 ? 90 : 0))
            {
                transform.Rotate(new Vector3(-(Time.deltaTime * 旋转速度), 0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler((按住 ? 90 : 0), 0, 0);
            }
        }
    }

  
}
