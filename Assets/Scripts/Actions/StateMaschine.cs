using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;



public class SquirrelStateMaschine : StateMaschine
{
    IdleState idle; // StateName: Idle
    MoveState move; // StateName: Move
    public override void setState(String stateName, StateData data) 
    {
    }

    public void setMoveState(Vector3 destination)
    {
        move.setDestination(destination);
        transitionToState(move);
    }

    public void setIdleState()
    {
        transitionToState(idle);
    }

    private void transitionToState(SMState state) 
    {
        if (current_state != null)
        {
            current_state.deinit();
        }        
        current_state = state;
        current_state.init();
    }

    public override SMState getState()
    {
        return current_state;
    }
    public override List<SMState> getStates() 
    {
        return states;
    }
    public override void init()
    {
        transitionToState(idle);
    }
    public override void deinit() { }

    public override void forceOut() { }

    public override StateState update() 
    {
        StateState state;
        switch (current_state) 
        {
            case IdleState _:
                state = current_state.update();
                break;
            case MoveState _:
                state = current_state.update();
                if (state == StateState.TRANSITION_OUT)
                {
                    transitionToState(idle);
                }
                break;
            default:
                state = this.state;
                break;
        }
        return state;
    }
    public override void transitionIn() { }

    public override void transitionOut() { }

    
}

public class AttackState : StateMaschine
{
    IdleState idle; // StateName: Idle
    MoveState move; // StateName: Move

    GameObject obj;
    public override void setState(String stateName, StateData data)
    {
    }
    public void setTarget(GameObject obj) 
    {
        this.obj = obj;
    }
    public void setMoveState(Vector3 destination)
    {
        move.setDestination(destination);
        transitionToState(move);
    }

    private void transitionToState(SMState state)
    {
        if (current_state != null)
        {
            current_state.deinit();
        }
        current_state = state;
        current_state.init();
    }

    public override SMState getState()
    {
        return current_state;
    }
    public override List<SMState> getStates()
    {
        return states;
    }
    public override void init()
    {
        transitionToState(idle);
    }
    public override void deinit() { }

    public override void forceOut() { }

    public override StateState update()
    {
        StateState state;
        switch (current_state)
        {
            case IdleState _:
                state = current_state.update();
                break;
            case MoveState _:
                state = current_state.update();
                if (state == StateState.TRANSITION_OUT)
                {
                    transitionToState(idle);
                }
                break;
            default:
                state = this.state;
                break;
        }
        return state;
    }
    public override void transitionIn() { }

    public override void transitionOut() { }


}
public enum StateState 
{
    STOPPED,
    RUNNING,
    TRANSITION_OUT
}
public class StateData 
{

}

public abstract class StateMaschine : SMState
{
    protected SMState current_state = null;

    protected List<SMState> states;

    public abstract void setState(String stateName, StateData data);
    public abstract SMState getState();
    public abstract List<SMState> getStates();
}
public abstract class SMState
{
    protected Squirrel squirrel;
    protected StateState state = StateState.STOPPED;
    public abstract void init();
    public abstract void deinit();

    public abstract void forceOut();

    public abstract StateState update();
    public abstract void transitionIn();

    public abstract void transitionOut();
}

public class IdleState : SMState
{
    public IdleState(Squirrel squirrel) 
    {
        this.squirrel = squirrel;
    }
    public override void deinit()
    {
    }

    public override void forceOut()
    {
    }

    public override void init()
    {
    }

    public override void transitionIn()
    {
    }

    public override void transitionOut()
    {
    }

    public override StateState update()
    {
        return state;
    }
}

public class MoveState : SMState
{
    Vector3 destination;
    public MoveState(Squirrel squirrel)
    {
        this.squirrel = squirrel;
    }
    public override void deinit()
    {
        NavMeshAgent agent = squirrel.GetComponent<NavMeshAgent>();
        agent.ResetPath();
    }

    public override void forceOut()
    {
    }

    public override void init()
    {
    }

    public override void transitionIn()
    {
    }

    public override void transitionOut()
    {
    }

    public override StateState update()
    {
        if (Vector3.Distance(this.squirrel.transform.position, destination) < 5f && state != StateState.TRANSITION_OUT)
        {
            state = StateState.TRANSITION_OUT;
        }
        return state;
    }

    public void setDestination(Vector3 destination) 
    {
        this.destination = destination;
        NavMeshAgent agent = squirrel.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.SetDestination(destination);
        }
    }
}
