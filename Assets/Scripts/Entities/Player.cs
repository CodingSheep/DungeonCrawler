using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//This sets a default speed for how fast our player can move in any direction
	public float speed = 5.0f;
    public float rotationSpeed;
	public float arrowSpeed = 40f;
	public float arrowDmg = 5f;

	private Camera mainCam;
	//private GameObject cursor;
	private Ray camRay; //Ray from camera to mouse position
	private RaycastHit camRayHit; //Hit point of raycast
	private Vector3 deltamovement;
    private GameController gamecontroller;
    private SpellController spellUI;

    private double timeHeld;
	private double test;
	private bool rightClicked;

    //For future use.
    void Start()
    {
		gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		//cursor = GameObject.FindGameObjectWithTag("Cursor");
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
        spellUI = GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>();

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
    }
    void LateUpdate() {
        if (!gamecontroller.playerIsFiring) {
            AimPlayer();
        }
    }

    void AimPlayer() {
		camRay = mainCam.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast(camRay, out camRayHit)) {
			Vector3 targetPos = new Vector3(camRayHit.point.x, transform.position.y, camRayHit.point.z);

            transform.LookAt(targetPos);
			transform.eulerAngles = transform.eulerAngles + 180 * Vector3.up;
		}
	}
}
