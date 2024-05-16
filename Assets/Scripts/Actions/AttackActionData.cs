using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackActionData : ActionData
{
    public GameObject target;
    public AttackActionData(GameObject target)
    {
        this.target = target;
        actionType = ActionType.Attack;
    }
}
