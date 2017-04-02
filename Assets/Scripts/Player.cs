using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//This sets a default speed for how fast our player can move in any direction
	public float speed = 5.0f;
	public float arrowSpeed = 40f;
	public float arrowDmg = 5f;

	private Camera mainCam;
	private GameObject cursor;
	private Ray camRay; //Ray from camera to mouse position
	private RaycastHit camRayHit; //Hit point of raycast
	private Vector3 deltamovement;
    private GameObject gamecontroller;

	private SpellAndArrowManager manager;

	private double timeHeld;
	private double test;
	private bool rightClicked;

    //For future use.
    void Start()
    {
		gamecontroller = GameObject.FindGameObjectWithTag("GameController");
		cursor = GameObject.FindGameObjectWithTag("Cursor");
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		manager = GameObject.Find ("SpellController").GetComponent<SpellAndArrowManager>();
		manager.setup ();

		timeHeld = 0.0;
    }

    //Every Frame I believe
    void Update()
	{
        //Uses the default Unity Input object too manage player input. This allows for multiple platforms, and easy customization in the future.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        deltamovement = transform.position + speed * (new Vector3(h, 0, v)).normalized * Time.deltaTime; //Vector of movement direction * time since last called.
        //Im very sure this bit is obvious, though I will explain the Time.deltaTime.
 		//Time.deltaTime is basically the time it took to finish the last frame
 		//It's used with speed to basically say "I want to move 5 meters per second, not 5 meters per frame"
	    
		transform.position = deltamovement;

		if (Input.GetMouseButtonDown (1))
			rightClicked = true;
		if (Input.GetMouseButtonUp (1))
			rightClicked = false;

		//Must pass this test first to see if we're firing a regular arrow or a basic arrow.

		/* Removed aim player check from update, moved it to fixedupdate
		if (timeHeld < 1.5)
			AimPlayer ();
		else */
		if (timeHeld >= 1.5)
			//For some reason, this causes an error right here. Any way to fix it?
			manager.toOsu ();

		//Handles whether we're starting a spell or a regular arrow
		if (rightClicked)
			timeHeld += Time.deltaTime;
		else {
			timeHeld = 0;

			//Spawns Basic Arrow. FIX SYNTAX
			//GameObject toSpawn = Instantiate (manager.basicArrow, player.transform.position, player.transform.rotation, this.transform);
		}
    }

	void FixedUpdate() {
		if (timeHeld < 1.5)
			AimPlayer ();
	}

	void AimPlayer() {
		camRay = mainCam.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast(camRay, out camRayHit)) {
			Vector3 targetPos = new Vector3(camRayHit.point.x, transform.position.y, camRayHit.point.z);
			//Custom cursor is jittery, using default cursor for now
			/*Vector3 cursorPos = new Vector3(camRayHit.point.x, transform.position.y-.9f, camRayHit.point.z);
			cursor.transform.position = cursorPos;*/
			transform.LookAt(targetPos);
			transform.eulerAngles = transform.eulerAngles + 180 * Vector3.up;
		}
	}
}
