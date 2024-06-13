using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleActionData : ActionData
{
    public Vector3 targetPosition;

    public IdleActionData()
    {
        actionType = ActionType.Idle;
    }
}
