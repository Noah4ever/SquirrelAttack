using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField]
    private bool isSelected = false;
    [SerializeField]
    private EntityType entityType = EntityType.None;

    /// <summary>
    /// Whether this clickable is currently selected.
    /// </summary>
    public bool IsSelected
    {
        get { return isSelected; }
    }

    /// <summary>
    /// The type of entity this clickable represents.
    /// </summary>
    public EntityType EntityType
    {
        get { return entityType; }
        set { entityType = value; }
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
