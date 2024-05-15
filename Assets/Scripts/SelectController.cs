using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectController : MonoBehaviour
{
    [SerializeField]
    private List<Clickable> selectedObjects = new List<Clickable>();

    public enum ClickType
    {
        Select, 
        ShiftSelect,
        Move, 
        Attack
    }

    public void Click(Vector3 screenClickPosition, ClickType clickType)
    {
        // Raycast 3D to find the object that was clicked
        Ray ray = Camera.main.ScreenPointToRay(screenClickPosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object is a clickable object
            Clickable clickable = hit.collider.GetComponent<Clickable>();
            if (clickable == null) return;

            switch (clickType)
            {
                case ClickType.Select:
                    DeselectAll();
                    SelectObject(clickable);
                    break;
                case ClickType.ShiftSelect:
                    ToggleSelectObject(clickable);
                    break;
                case ClickType.Move:
                    MoveObject(clickable);
                    break;
                case ClickType.Attack:
                    AttackObject(clickable);
                    break;
            }

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

    private void MoveObject(Clickable clickable)
    {
        // Loop through all selected objects
        foreach (Clickable selectedObject in selectedObjects)
        {
            // Get the lifeform component of the selected object
            selectedObject.GetComponent<Lifeform>();
            if (selectedObject.GetComponent<Lifeform>() == null) continue;
            // Call the doAction method of the lifeform component with an MoveActionData object
            selectedObject.GetComponent<Lifeform>().doAction(new MoveActionData(clickable.transform.position));
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
