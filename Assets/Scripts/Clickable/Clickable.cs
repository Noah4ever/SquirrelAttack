using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField]
    private bool isSelected = false;
    [SerializeField]

    /// <summary>
    /// Whether this clickable is currently selected.
    /// </summary>
    public bool IsSelected
    {
        get { return isSelected; }
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
