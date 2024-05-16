using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngineInternal;
using static Codice.Client.Commands.WkTree.WorkspaceTreeNode;

public class SelectController : MonoBehaviour
{
    [SerializeField]
    private List<Clickable> selectedObjects = new List<Clickable>();

    public enum ClickType
    {
        Select, 
        ShiftSelect,
        RightClick
    }

    // TODO: Please redo this hell. Especially the if(selectedObjects.Count > 0) part.
    // TODO: Implement should not be able to select enemy and friendly at the same time.
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
            if (clickable == null && clickType == ClickType.Select ) {
                DeselectAll();
                return;
            } // Exit if the object is not clickable

            // Handle the click based on whether there are selected objects
            if (selectedObjects.Count > 0)
            {
                HandleSelectedObjectsClick(clickable, hit.point, clickType);
            }
            else
            {
                HandleNoSelectedObjectsClick(clickable, clickType);
            }
        }
    }

    private void HandleSelectedObjectsClick(Clickable clickable, Vector3 hitPoint, ClickType clickType)
    {
        // Handle click when there are selected objects
        switch (clickType)
        {
            case ClickType.RightClick:
                // Move the selected object(s) to the clicked point
                MoveObject(hitPoint);
                break;
            case ClickType.Select:
                // Handle selection click with selected objects
                HandleSelectClickWithSelectedObjects(clickable);
                break;
            case ClickType.ShiftSelect:
                // Toggle the selection state of the clicked object
                ToggleSelectObject(clickable);
                break;
        }
    }

    private void HandleNoSelectedObjectsClick(Clickable clickable, ClickType clickType)
    {
        // Handle click when there are no selected objects
        if (clickType == ClickType.Select)
        {
            // Select the clicked object
            SelectObject(clickable);
        }
    }

    private void HandleSelectClickWithSelectedObjects(Clickable clickable)
    {
        // Handle selection click based on the team type of the clicked object
        if (clickable.TeamType == TeamType.Enemy)
        {
            // Attack the clicked enemy object
            AttackObject(clickable);
        }
        else if (clickable.TeamType == TeamType.Friendly)
        {
            // Deselect all currently selected objects and select the clicked friendly object
            DeselectAll();
            SelectObject(clickable);
        }
    }

    private void AttackObject(Clickable clickable)
    {
        // Loop through all selected objects
        foreach (Clickable selectedObject in selectedObjects)
        {
            // Get the lifeform component of the selected object
            selectedObject.GetComponent<Lifeform>();
            if (selectedObject.GetComponent<Lifeform>() == null) continue;
            // Call the doAction method of the lifeform component with an AttackActionData object
            selectedObject.GetComponent<Lifeform>().doAction(new AttackActionData(clickable.gameObject));
        }
    }

    private void MoveObject(Vector3 hitPoint)
    {
        // Loop through all selected objects
        foreach (Clickable selectedObject in selectedObjects)
        {
            // Get the lifeform component of the selected object
            selectedObject.GetComponent<Lifeform>();
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
