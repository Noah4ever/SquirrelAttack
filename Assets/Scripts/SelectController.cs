using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectController : MonoBehaviour
{

    // vector of selected objects
    // private List<Clickable> selectedObjects = new List<Clickable>();

    public enum ClickType
    {
        ClickOne, // Single Click
        ClickAddRemove, // Shift Click
    }

    private void addSelected(Clickable clickable, ClickType clickType)
    {

        if (clickType == ClickType.ClickOne)
        {
            DeselectAll();
            // selectedObjects.Add(clickable);
        }
        else if (clickType == ClickType.ClickAddRemove)
        {
            // if(selectedObjects.Contains(clickable))
            // {
            //     selectedObjects.Remove(clickable);
            // }
            // else
            // {
            //     selectedObjects.Add(clickable);
            // }
        }

    }

    private void DeselectAll()
    {
        // foreach (Clickable selectedObject in selectedObjects)
        // {
        //     selectedObject.Deselect();
        // }
        // selectedObjects.Clear();
    }

    public /*Clickable*/ void Click(Vector2 screenClickPosition, ClickType clickType)
    {
        // Raycast 3D to find the object that was clicked
        Ray ray = Camera.main.ScreenPointToRay(screenClickPosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object is a selectable object
            Clickable clickable = hit.collider.GetComponent<Clickable>();
            if (clickable == null)
            {
                // Select the object

                // clickable.Select();
                // addSelected(clickable, clickType);
                // return clickable;
            }
        }
    }

    public /*Clickable*/ void Select(Vector2 screenClickPosition1, Vector2 screenClickPosition2, ClickType clickType)
    {

        

    }


}
