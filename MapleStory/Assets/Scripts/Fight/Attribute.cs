using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    public AttributeData_So AttributeData_So;
    public int entityHp;
    public int entityMp;
    public float moveSpeed;
    public float jumpForce;
    public int entityAtk;

    private void Awake()
    {
        AttributeSet(AttributeData_So);
    }

    void AttributeSet(AttributeData_So attributeData)
    {
        this.entityHp = attributeData.entityHp;
        this.entityMp = attributeData.entityMp;
        this.moveSpeed = attributeData.moveSpeed;
        this.jumpForce = attributeData.jumpForce;
        this.entityAtk = attributeData.entityAtk;
    }
}
