using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Updateable : MonoBehaviour, IUpdateable
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

    protected void addToTimeController() 
    {
        timeController.AddUpdateable(this);
    }

    /// <summary>
    /// Start the time controller and add this object to the updateable list
    /// </summary>
    protected virtual void Start()
    {        
        timeController = getTimeController();
    }
    /// <summary>
    /// Gets the GameController Component in the Scene
    /// </summary>
    /// <returns> The GameController Component in the Scene </returns>
    protected GameController getGameController() 
    {
        GameObject gameControllerGO = GameObject.Find("GameController");
        Debug.Assert(gameControllerGO != null, "Could Not Find GameController GameObject in the Scene");

        GameController gameController = gameControllerGO.GetComponent<GameController>();
        Debug.Assert(gameController != null, "Could Not Find GameController Component on the GameController GameObject");

        return gameController;
    }
    /// <summary>
    /// Gets the TimeController Component in the Scene
    /// </summary>
    /// <returns> The TimeController Component in the Scene </returns>
    protected TimeController getTimeController()
    {
        GameObject timeControllerGO = GameObject.Find("TimeController");
        Debug.Assert(timeControllerGO != null, "Could Not Find TimeController GameObject in the Scene");

        TimeController timeController = timeControllerGO.GetComponent<TimeController>();
        Debug.Assert(timeController != null, "Could Not Find TimeController Component on the TimeController GameObject");

        return timeController;
    }

    protected SelectController getSelectController()
    {
        GameObject selectcontrollerGo = GameObject.Find("SelectController");
        Debug.Assert(selectcontrollerGo != null, "Could Not Find SelectController GameObject in the Scene");

        SelectController selectController = selectcontrollerGo.GetComponent<SelectController>();
        Debug.Assert(selectController != null, "Could Not Find SelectController Component on the SelectController GameObject");

        return selectController;
    }


    /// <summary>
    /// Check if the object can update and call the update method
    /// </summary>
    protected virtual void Update()
    {
        if (canUpdate)
        {
            update();
        }
    }

    /// <summary>
    /// Update method to be overridden by child classes
    /// </summary>
    public virtual void update()
    {
        // Override this method in the child class
    }
}
