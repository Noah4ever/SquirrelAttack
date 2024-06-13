using UnityEngine.AI;
using UnityEngine;
using Codice.Client.Common;
using Codice.CM.Common.Workspaces;

public abstract class SquirrelAction
{
    protected Squirrel squirrel;
    public abstract void execute();
    public abstract void update(int currentTick);
    public abstract void end();
}

public class SquirrelMove : SquirrelAction
{
    MoveActionData actionData;
    public SquirrelMove(Squirrel squirrel, MoveActionData actionData)
    {
        this.squirrel = squirrel;
        this.actionData = actionData;
    }
    public override void execute()
    {
        this.squirrel.setDestination(actionData.targetPosition);
    }
    public override void end()
    {
        this.squirrel.resetDestination();
    }

    public override void update(int currentTick)
    {
    }
}

public class SquirrelAttack : SquirrelAction
{
    GameObject target;
    int nextUpdate;
    int updateInterval = 1;
    int attackDistance = 3;
    int attackInterval = 3;
    int lastAttackTime = int.MinValue;
    public SquirrelAttack(Squirrel squirrel, GameObject target, int nextUpdate)
    {
        this.squirrel = squirrel;
        this.target = target;
        this.nextUpdate = nextUpdate;
    }
    public override void execute()
    {
    }
    public override void end()
    {
        this.squirrel.resetDestination();
    }

    public override void update(int currentTick)
    {
        if (this.nextUpdate < currentTick)
        {
            if (Vector3.Distance(this.squirrel.transform.position, target.transform.position) < attackDistance && lastAttackTime + attackInterval < currentTick)
            {
                // Start Atack Animation
                // Damage opponent ?
                this.lastAttackTime = currentTick;
            }
            nextUpdate = currentTick + updateInterval;
        }
    }
}

public class SquirrelFollow : SquirrelAction
{
    FollowActionData followActionData;
    int nextUpdate;
    int updateInterval = 1;
    public SquirrelFollow(Squirrel squirrel, FollowActionData followActionData, int nextUpdate)
    {
        this.squirrel = squirrel;
        this.followActionData = followActionData;
        this.nextUpdate = nextUpdate;
    }
    public override void execute()
    {
        this.squirrel.setDestination(followActionData.targetFollow.transform.position);
    }
    public override void end()
    {
        this.squirrel.resetDestination();
    }

    public override void update(int currentTick)
    {
        if (this.nextUpdate < currentTick) 
        {
            execute();
            nextUpdate = currentTick + updateInterval;
        }
    }
}

public class SquirrelIdel : SquirrelAction
{
    Updateable target;
    public SquirrelIdel(Squirrel squirrel)
    {
        this.squirrel = squirrel;
    }
    public override void execute()
    {

    }
    public override void end()
    {
    }

    public override void update(int currentTick)
    {

    }
}
