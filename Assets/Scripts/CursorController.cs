using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectController;

public class CursorController : MonoBehaviour
{
    public Texture2D cursorPoint;
    public Texture2D cursorSelect;
    public Texture2D cursorMove;
    public Texture2D cursorAttack;
    public Texture2D cursorFollow;

    public enum ClickActionType
    {
        Select,
        Move,
        Attack,
        Follow,
        Point
    }

    public ClickActionType setCursor(ClickActionType clickActionType)
    {
        switch (clickActionType)
        {
            case ClickActionType.Select:
                Cursor.SetCursor(cursorSelect, Vector2.zero, CursorMode.Auto);
                return ClickActionType.Select;
            case ClickActionType.Move:
                Cursor.SetCursor(cursorMove, Vector2.zero, CursorMode.Auto);
                return ClickActionType.Move;
            case ClickActionType.Attack:
                Cursor.SetCursor(cursorAttack, Vector2.zero, CursorMode.Auto);
                return ClickActionType.Attack;
            case ClickActionType.Follow:
                Cursor.SetCursor(cursorFollow, Vector2.zero, CursorMode.Auto);
                return ClickActionType.Follow;
            case ClickActionType.Point:
                Cursor.SetCursor(cursorPoint, Vector2.zero, CursorMode.Auto);
                return ClickActionType.Point;
            default:
                Cursor.SetCursor(cursorPoint, Vector2.zero, CursorMode.Auto);                    
                return ClickActionType.Point;
        }
    }
}
