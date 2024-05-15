using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeform : Updateable
{
    [SerializeField]
    private float speed { get; set; }
    [SerializeField]
    private float fear { get; set; }
    [SerializeField]
    private float mood { get; set; }
    [SerializeField]
    private float damage { get; set; }
    [SerializeField]
    private float attackRadius { get; set; }
    [SerializeField]
    private float presence { get; set; }
    [SerializeField]
    private float presenceRadius { get; set; }

    [SerializeField]
    private List<ActionType> actions;

    [SerializeField]
    private TeamType teamType { get; }

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
