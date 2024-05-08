using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Updateable
{
    private GameController gameController;
    void Start()
    {
        base.Start();

        gameController = getGameController();
    }

    void Update()
    {
        base.Update();
    }

    public void Move()
    {
        // Move the player
    }

    /// <summary>
    /// Pause/Unpause the game
    /// </summary>
    public void Pause()
    {
        gameController.TogglePause();
    }
}
