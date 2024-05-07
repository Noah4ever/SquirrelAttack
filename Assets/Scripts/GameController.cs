using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private TimeController timeController;

    void Start()
    {
        timeController = GetComponent<TimeController>();
    }


    void Update()
    {
        
    }

    /// <summary>
    /// Pause/Unpause the game
    /// </summary>
    public void TogglePause()
    {
        if(timeController.isPaused)
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
}
