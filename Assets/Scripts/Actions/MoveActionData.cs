using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveActionData : ActionData
{
    public Vector3 targetPosition;

    public MoveActionData(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        actionType = ActionType.Move;
    }
}
