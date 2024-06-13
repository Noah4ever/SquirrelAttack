using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Dropdown;

public class Squirrel : Animal
{
    public SquirrelAction currentSquirrelAction;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currentSquirrelAction = new SquirrelIdel(this);
        actions.Add(ActionType.Idle);
        actions.Add(ActionType.Move);
        actions.Add(ActionType.Attack);
        actions.Add(ActionType.Follow);
        addToTimeController();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        currentSquirrelAction.update(timeController.GetCurrentTick());
    }

    public override void doAction(ActionData actionData)
    {
        currentSquirrelAction.end();
        switch (actionData.actionType)
        {
            case ActionType.Idle:
                currentSquirrelAction = new SquirrelIdel(this);
                break;
            case ActionType.Attack:
                currentSquirrelAction = new SquirrelAttack(this, ((AttackActionData)actionData), timeController.GetCurrentTick());
                break;
            case ActionType.Move:
                currentSquirrelAction = new SquirrelMove(this, ((MoveActionData)actionData));
                break;
            case ActionType.Follow:
                currentSquirrelAction = new SquirrelFollow(this, ((FollowActionData)actionData), timeController.GetCurrentTick());
                break;
            default:
                break;
        }
        currentSquirrelAction.execute();
    }
    public void setDestination(Vector3 destination)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = destination;
    }
    public void resetDestination()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.ResetPath();
    }
}
