using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float tickRate = 1.0f; // The rate at which ticks occur (ticks per second)
    private float timer = 0.0f; // Timer to keep track of when to increment ticks
    private int currentTick = 0;

    public bool isRunning = true;

    private List<IUpdateable> updateables = new List<IUpdateable>();

    public void Start()
    {
    }

    void Update()
    {
        // Increment timer by the time since the last frame
        timer += Time.deltaTime;
        // If enough time has passed based on tick rate, increment the tick count
        while (timer >= 1.0f / tickRate)
        {
            currentTick++;
            timer -= 1.0f / tickRate;
        }
        if(isRunning)
        {
            StartTime();
        }
        else
        {
            StopTime();
        }
    }

    /// <summary>
    /// Returns the current tick count
    /// </summary>
    /// <returns>current tick count</returns>
    public int GetCurrentTick()
    {
        return currentTick;
    }

    /// <summary>
    /// Add an object to the list of objects that need to be updated
    /// </summary>
    /// <param name="updateable"></param>
    public void AddUpdateable(IUpdateable updateable)
    {
        updateables.Add(updateable);
    }

    /// <summary>
    /// Remove an object from the list of objects that need to be updated
    /// </summary>
    /// <param name="updateable"></param>
    public void RemoveUpdateable(IUpdateable updateable)
    {
        updateables.Remove(updateable);
    }

    /// <summary>
    /// Start update for all objects that need to be updated
    /// </summary>
    public void StartTime()
    {
        Console.WriteLine("Starting Time");
        foreach (IUpdateable updateable in updateables)
        {
            updateable.StartUpdate();
        }
    }

    /// <summary>
    /// Stop update for all objects that need to be updated
    /// </summary>
    public void StopTime()
    {
        foreach (IUpdateable updateable in updateables)
        {
            updateable.StopUpdate();
        }
    }

}
