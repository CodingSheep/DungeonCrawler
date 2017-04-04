﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public GameObject OsuCircle;
    private SpellController spellController;
    public bool playerIsFiring;

	void Start () {
        spellController = GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>();
        playerIsFiring = false;

    }

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {
			//creates game object
			GameObject osu_Circle= Instantiate (OsuCircle);

			//displaces the circle 2 times its size above player
			float displacement = osu_Circle.transform.localScale.x * 50;

			//sets postions and parent
			osu_Circle.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform);
			osu_Circle.transform.position = new Vector2 (Screen.width / 2, Screen.height / 2 + displacement);
		}

        //Basic arrow shot (right click)
        if (Input.GetButtonDown("Fire2"))
        {
            //if (finalHit == null)
            spellController.StartSpawnSequence();
            playerIsFiring = true;

        }
        if (Input.GetButtonUp("Fire2")) {
            spellController.EndSpawnSequence();
            playerIsFiring = false;
        }

    }
}
