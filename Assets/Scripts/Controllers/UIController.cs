using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    private GameObject player;

    public Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

    public GameObject AimLine;
    public GameObject ShootingAimLine;
    private GameObject shootline;
    public bool isShooting;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        isShooting = false;
        //ShootingAimLine.transform = player.transform;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
