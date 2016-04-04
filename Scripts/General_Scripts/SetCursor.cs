using UnityEngine;
using System.Collections;

public class SetCursor : MonoBehaviour {

    public Texture2D cursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

	void Start () {
        Cursor.SetCursor(cursor, hotSpot, cursorMode);
	}
}
