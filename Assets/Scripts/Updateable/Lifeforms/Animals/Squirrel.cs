using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Dropdown;

public class Squirrel : Animal
{
    public ActionData currentAction;
    public SquirrelAction currentSquirrelAction;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currentSquirrelAction = new SquirrelIdel(this);
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
    switch(actionData.actionType)
    {
        case ActionType.Attack:
            Attack((AttackActionData)actionData);
            break;
        case ActionType.Move:
            currentSquirrelAction = new SquirrelMove(this,((MoveActionData)actionData).targetPosition);
            
            break;
        case ActionType.Follow:
            currentSquirrelAction = new SquirrelFollow(this, ((FollowActionData)actionData).targetFollow,timeController.GetCurrentTick());
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
    private void Move(MoveActionData actionData)
    {
    }

    private void Attack(AttackActionData actionData)
    {
        Debug.Log("Squirrel should attack: " + actionData.target.transform.position);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = actionData.target.transform.position;
    }

    private void Follow(FollowActionData actionData)
    {
        Debug.Log("Squirrel should follow: " + actionData.targetFollow.transform.position);
    }
}
