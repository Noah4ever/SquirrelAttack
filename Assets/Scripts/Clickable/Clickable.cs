using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField]
    private bool isSelected = false;
    [SerializeField]
    private TeamType teamType;

    SelectController selectController;

    private void Start()
    {
        if(selectController == null) 
        {
            selectController = GameObject.Find("SelectController").GetComponent<SelectController>();
        }
    }

    /// <summary>
    /// Whether this clickable is currently selected.
    /// </summary>
    public bool IsSelected
    {
        get { return isSelected; }
    }

    /// <summary>
    /// The team type of this clickable.
    /// </summary>
    public TeamType TeamType
    {
        get { return teamType; }
    }

    /// <summary>
    /// Selects this clickable.
    /// </summary>
    public void Select()
    {
        isSelected = true;
    }
    /// <summary>
    /// Deselects this clickable.
    /// </summary>
    public void Deselect()
    {
        isSelected = false;
    }

    private void OnMouseEnter()
    {
        selectController.onMouseEnter(this);
    }

    private void OnMouseExit()
    {
        selectController.onMouseExit(this);
    }
}
