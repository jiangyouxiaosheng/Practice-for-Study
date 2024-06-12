using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : Singleton<FightManager>
{



    public void ToDamage(Attribute initiator,Attribute target)
    {
        if (target.entityHp - initiator.entityAtk > 0 )
        {
            target.entityHp -= initiator.entityAtk;
        }
        else
        {
            target.entityHp = 0;
        }
       
    }


}
