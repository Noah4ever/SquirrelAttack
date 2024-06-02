using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private PlayerController playerController;

    private TimeController timeController;

    void Start()
    {
        if (timeController == null)
        { 
            timeController = getTimeController();
        }
        if (playerController == null)
        {
            playerController = getPlayerController();
        }
    }


    void Update()
    {
        
    }

    /// <summary>
    /// Pause/Unpause the game
    /// </summary>
    public void TogglePause()
    {
        if(timeController.isRunning)
        {
            StartTime();
        }
        else
        {
            StopTime();
        }
    }
    /// <summary>
    /// Start the game via time controller
    /// </summary>
    public void StartTime()
    {
        timeController.StartTime();
    }
    /// <summary>
    ///  Stop the game via time controller
    /// </summary>
    public void StopTime()
    {
        timeController.StopTime();
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
    protected PlayerController getPlayerController()
    {
        GameObject timeControllerGO = GameObject.Find("PlayerController");
        Debug.Assert(timeControllerGO != null, "Could Not Find PlayerController GameObject in the Scene");

        PlayerController timeController = timeControllerGO.GetComponent<PlayerController>();
        Debug.Assert(timeController != null, "Could Not Find PlayerController Component on the PlayerController GameObject");

        return timeController;
    }
}
