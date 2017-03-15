using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;
    // Use this for initialization
    void Start () {
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
