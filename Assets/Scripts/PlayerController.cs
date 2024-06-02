using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Updateable
{
    private GameController gameController;
    private SelectController selectController;

    private bool isShiftDown = false;

    new void Start()
    {
        base.Start();

        gameController = getGameController();
        GameObject selectcontrollerGo = GameObject.Find("SelectController");
        selectController = selectcontrollerGo.GetComponent<SelectController>();
        addToTimeController();
    }

    new void Update()
    {
        base.Update();
    }

    /// <summary>
    /// Pause/Unpause the game
    /// </summary>
    public void Pause()
    {
        gameController.TogglePause();
    }

    public override void update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isShiftDown = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            isShiftDown = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(isShiftDown)
            {
                // Shift select
                selectController.Click(Input.mousePosition, SelectController.ClickType.ShiftLeftClick);
            }
            else
            {
                // Normal Select
                selectController.Click(Input.mousePosition, SelectController.ClickType.LeftClick);
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            selectController.Click(Input.mousePosition, SelectController.ClickType.RightClick);
        }


    }
}
