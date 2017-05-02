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

	public bool isPause = false;

	public List<GameObject> circleTypes;

    public GameObject OsuCircle;
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

    public void Shooting() {
        isShooting = true;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height/2, 0.0f);
        //Debug.Log(center);
        //Debug.Log(Input.mousePosition + " mouse");
        Vector3 Radial = center + (Input.mousePosition - center).normalized * 200;

		for (int i = 0; i < circleTypes.Count; i++) {
			Vector3 offset = new Vector3 (Mathf.Cos(2 * Mathf.PI * ((float)i/circleTypes.Count)), Mathf.Sin(2 * Mathf.PI * ((float)i/circleTypes.Count)), 0);
			GameObject toSpawn = Instantiate(circleTypes[i], center + (offset * 200), Quaternion.identity, this.transform ) as GameObject;
		}
	}

    public void Release() {
        isShooting = false;
        GameObject[] Circles = GameObject.FindGameObjectsWithTag("OsuCircle");

        for (var i = 0; i < Circles.Length; i++) {
            Destroy(Circles[i]);
        }
    }
}
