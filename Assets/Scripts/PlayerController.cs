using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Updateable
{
    private GameController gameController;
    private SelectController selectController;

    void Start()
    {
        base.Start();

        gameController = getGameController();
        selectController = getSelectController();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            selectController.Click(Input.mousePosition, SelectController.ClickType.Select);
        }
        else if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            selectController.Click(Input.mousePosition, SelectController.ClickType.ShiftSelect);
        }

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
