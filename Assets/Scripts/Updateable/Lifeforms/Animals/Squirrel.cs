using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        actions.Add(ActionType.Move);
        actions.Add(ActionType.Attack);
        actions.Add(ActionType.Follow);
        addToTimeController();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

public override void doAction(ActionData actionData)
{
    switch(actionData.actionType)
    {
        case ActionType.Attack:
            Attack((AttackActionData)actionData);
            break;
        case ActionType.Move:
            Move((MoveActionData)actionData);
            break;
        case ActionType.Follow:
            Follow((FollowActionData)actionData);
            break;
        default:
            break;
    }
}

    private void Move(MoveActionData actionData)
    {
        Debug.Log("Squirrel should move to: " + actionData.targetPosition);
    }

    private void Attack(AttackActionData actionData)
    {
        Debug.Log("Squirrel should attack: " + actionData.target.transform.position);
    }

    private void Follow(FollowActionData actionData)
    {
        Debug.Log("Squirrel should follow: " + actionData.targetFollow.transform.position);
    }
}
