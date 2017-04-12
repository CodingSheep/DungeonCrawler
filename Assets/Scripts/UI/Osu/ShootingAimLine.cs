using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAimLine : MonoBehaviour {
    private Camera mainCam;
    private SpellController spellController;
    private GameController gameController;

    private Ray camRay; //Ray from camera to mouse position
    private RaycastHit camRayHit; //Hit point of raycast

    private float osuTime;
    private LineRenderer lineren;
    private GameObject player;

    private Vector3 targetPos;
    private Vector3 playerPos;
    private Vector3 previousMousePosition;
    // Use this for initialization
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
