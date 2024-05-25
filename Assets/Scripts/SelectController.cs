using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField]
    private List<Clickable> selectedObjects = new List<Clickable>();

    public enum ClickType
    {
        LeftClick, 
        ShiftLeftClick,
        RightClick,
        ShiftRightClick
    }

    public enum ClickActionType
    {
        Select,
        Move,
        Attack,
        Follow,
        Point
    }

    public void Hover(Vector3 mouseScreenPos)
    {
        // Convert the screen position to a ray
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Get the Clickable component from the hit object
            Clickable clickable = hit.collider.GetComponent<Clickable>();

            if (clickable != null)
            {
                // Clickable is a clickable object
                switch (clickable.TeamType)
                {
                    case TeamType.Friendly:
                        setMouseCursor(ClickActionType.Select);
                        break;
                    case TeamType.Enemy:
                        if(hasSelectedObjects())
                        {
                            setMouseCursor(ClickActionType.Attack);
                        }
                        else
                        {
                            setMouseCursor(ClickActionType.Select);
                        }
                        break;
                    default:
                        setMouseCursor(ClickActionType.Select);
                        break;
                }
            }
            else
            {
                // Clickable is not a clickable object
                setMouseCursor(ClickActionType.Point);
            }

        }
    }

    private void setMouseCursor(ClickActionType clickActionType)
    {
        switch (clickActionType)
        {
            case ClickActionType.Select:
                // TODO: Set mouse cursor to select
                break;
            case ClickActionType.Move:
                // TODO: Set mouse cursor to move
                break;
            case ClickActionType.Attack:
                // TODO: Set mouse cursor to attack
                break;
            case ClickActionType.Follow:
                // TODO: Set mouse cursor to follow
                break;
            case ClickActionType.Point:
                // TODO: Set mouse cursor to point
                break;
            default:
                // TODO: Set mouse cursor to point
                break;
        }
    }


    // TODO: Test this shit
    public void Click(Vector3 screenClickPosition, ClickType clickType)
    {
        // Convert the screen click position to a ray
        Ray ray = Camera.main.ScreenPointToRay(screenClickPosition);
        RaycastHit hit;

        // Perform a raycast to detect what was clicked
        if (Physics.Raycast(ray, out hit))
        {
            // Get the Clickable component from the hit object
            Clickable clickable = hit.collider.GetComponent<Clickable>();

            if (clickable == null && clickType == ClickType.LeftClick) {
                DeselectAll();
                return;
            }

            if (clickable != null && clickType == ClickType.LeftClick)
            {
                DeselectAll();
                SelectObject(clickable);
            }
            else if (clickable != null && clickType == ClickType.ShiftLeftClick)
            {
                // check if the clickable is of the same type as the selected objects
                if (selectedObjects.Count > 0)
                {
                    if (selectedObjects[0].TeamType == clickable.TeamType)
                    {
                        ToggleSelectObject(clickable);
                    }
                    else
                    {
                        if (hasSelectedObjects())
                        {

                        DeselectAll();
                        }
                        SelectObject(clickable);
                    }
                }
                else
                {
                    SelectObject(clickable);
                }
            }
            else if (clickType == ClickType.RightClick)
            {
                if (selectedObjects.Count > 0)
                {
                    if (selectedObjects[0].TeamType != TeamType.Friendly) return;
                    if(clickable == null)
                    {
                        MoveObject(hit.point);
                    }
                    else
                    {
                        HandleSelectedObjectsClick(clickable, hit.point);
                    }
                }
                else
                {
                    // Context menu
                }
            }
            else if (clickType == ClickType.ShiftRightClick)
            {
                // Not implemented yet
                // Maybe implement a walk path with multiple waypoints
            }

        }
    }

    private void HandleSelectedObjectsClick(Clickable clickable, Vector3 hitPoint)
    {
        // Handle click when there are selected objects
        switch (clickable.TeamType)
        {
            case TeamType.Friendly:
                // Right Click on Friendly should follow the clicked object
                FollowObject(clickable);
                break;
            case TeamType.Enemy:
                AttackObject(clickable);
                break;
            case TeamType.Neutral:
                MoveObject(hitPoint);
                break;
            default:
                MoveObject(hitPoint);
                break;
        }
    }

    private void AttackObject(Clickable clickable)
    {
        // Loop through all selected objects
        foreach (Clickable selectedObject in selectedObjects)
        {
            // Get the lifeform component of the selected object
            if (selectedObject.GetComponent<Lifeform>() == null) continue;
            // Call the doAction method of the lifeform component with an AttackActionData object
            selectedObject.GetComponent<Lifeform>().doAction(new AttackActionData(clickable.gameObject));
        }
    }

    private void FollowObject(Clickable clickable)
    {
        // Loop through all selected objects
        foreach (Clickable selectedObject in selectedObjects)
        {
            // Get the lifeform component of the selected object
            if (selectedObject.GetComponent<Lifeform>() == null) continue;
            // Call the doAction method of the lifeform component with an FollowActionData object
            selectedObject.GetComponent<Lifeform>().doAction(new FollowActionData(clickable.gameObject));
        }
    }
    private void MoveObject(Vector3 hitPoint)
    {
        // Loop through all selected objects
        foreach (Clickable selectedObject in selectedObjects)
        {
            // Get the lifeform component of the selected object
            if (selectedObject.GetComponent<Lifeform>() == null) continue;
            // Call the doAction method of the lifeform component with an MoveActionData object
            selectedObject.GetComponent<Lifeform>().doAction(new MoveActionData(hitPoint));
        }
    }

    private void SelectObject(Clickable clickable)
    {
        clickable.Select();
        selectedObjects.Add(clickable);
    }

    private void ToggleSelectObject(Clickable clickable)
    {
        if (selectedObjects.Contains(clickable))
        {
            clickable.Deselect();
            selectedObjects.Remove(clickable);
        }
        else
        {
            clickable.Select();
            selectedObjects.Add(clickable);
        }
    }   

    public void DeselectAll()
    { 
        if (selectedObjects.Count == 0) return;
        foreach (Clickable selectedObject in selectedObjects)
        {
            selectedObject.Deselect();
        }
        selectedObjects.Clear();
    }

    public bool hasSelectedObjects()
    {
        return selectedObjects.Count > 0;
    }

    public void Select(Vector2 screenClickPosition1, Vector2 screenClickPosition2, ClickType clickType)
    {
        throw new System.NotImplementedException();
    }


}
