using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updateable : MonoBehaviour, IUpdateable
{
    protected bool canUpdate = false;
    protected TimeController timeController;

    /// <summary>
    /// Start updating the object
    /// </summary>
    public void StartUpdate()
    {
        canUpdate = true;
    }

    /// <summary>
    /// Stop updating the object
    /// </summary>
    public void StopUpdate()
    {
        canUpdate = false;
    }

    /// <summary>
    /// Start the time controller and add this object to the updateable list
    /// </summary>
    void Start()
    {
        timeController = GetComponent<TimeController>();        
        timeController.AddUpdateable(this);
    }

    /// <summary>
    /// Check if the object can update and call the update method
    /// </summary>
    void Update()
    {
        if (canUpdate)
        {
            update();
        }
    }

    /// <summary>
    /// Update method to be overridden by child classes
    /// </summary>
    virtual public void update()
    {
        // Override this method in the child class
    }
}
