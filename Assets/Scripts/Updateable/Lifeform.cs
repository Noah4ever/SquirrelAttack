using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeform : Updateable
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float fear;
    [SerializeField]
    protected float mood;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float attackRadius;
    [SerializeField]
    protected float presence;
    [SerializeField]
    protected float presenceRadius;

    [SerializeField]
    protected List<ActionType> actions;

    /// <summary>
    /// Override this method to implement the lifeform's behavior
    /// </summary>
    public override void update()
    {
        // Implement the lifeform's behavior here
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
         base.Update();
    }

    /// <summary>
    /// Override this method to implement the lifeform's action(s). For all ActionTypes in 'actions'
    /// <code class="cpp">
    /// switch(actionData.actionType)
    /// {
    ///     case ActionType.Attack:
    ///         Attack();
    ///         break;
    ///     case ActionType.Move:
    ///         Move();
    ///         break;
    ///     default:
    ///         break;
    ///  }
    /// </code>
    /// </summary>
    /// <param name="actionData"></param>
    public virtual void doAction(ActionData actionData)
    {
    }
}
