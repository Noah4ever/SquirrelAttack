using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameController gameController;
    void Start()
    {
        gameController = GetComponent<GameController>();
    }

    void Update()
    {
        
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
