using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAimLine : MonoBehaviour {
    /*!
     * A line to handle aiming with the mouse down and too approximate the time it's been since the arrow has been loaded
     */
    private Camera mainCam; //!< mainCamera object
    private SpellController spellController; //!< SpellController
    private GameController gameController; //!< GameController

    private Ray camRay; //!< Ray from camera to mouse position
    private RaycastHit camRayHit; //!< Hit point of raycast

    private float osuTime; //!< Time since rightclick has been held
    private LineRenderer lineren; //!< Linerenderer of the line
    private GameObject player; //!< Player object to know position

    private Vector3 targetPos; //!< Target position (where cursor is after some transforms
    private Vector3 playerPos; //!< Player's current position
    private Vector3 previousMousePosition; //!< Keeps track of delta movements
    // Use this for initialization
    /*!
     * Sets member functions
     */
    void Start () {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        spellController = GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        lineren = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        targetPos = player.transform.position;
        playerPos = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z);
        osuTime = spellController.GetOsuTime();
        previousMousePosition = Vector3.zero;
    }
    /*!
     * Updates last since it is GUI element to eleminate apparent UI issues
     */
	void LateUpdate () {
        playerPos = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z);
        lineren.SetPosition(0, playerPos);

        if (!gameController.playerIsFiring) {
            previousMousePosition = Input.mousePosition;
        }

        camRay = mainCam.ScreenPointToRay(previousMousePosition);
        if (Physics.Raycast(camRay, out camRayHit)) {
            targetPos = new Vector3(camRayHit.point.x, 0.0f, camRayHit.point.z);
            transform.LookAt(targetPos);
            transform.eulerAngles = transform.eulerAngles + 180 * Vector3.up;
        }

        osuTime = spellController.GetOsuTime();
        targetPos = (-(playerPos - targetPos).normalized * osuTime) + playerPos;
        lineren.SetPosition(1, targetPos);
    }
}
