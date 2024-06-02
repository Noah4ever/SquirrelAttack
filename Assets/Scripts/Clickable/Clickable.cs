using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField]
    private bool isSelected = false;
    [SerializeField]
    private TeamType teamType;

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

}
