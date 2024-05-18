using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowActionData : ActionData
{
    public GameObject targetFollow;
    public FollowActionData(GameObject target)
    {
        this.targetFollow = target;
        actionType = ActionType.Follow;
    }
}