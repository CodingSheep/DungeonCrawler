﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {
    private UIController UIController;
    private GameController GameController;
	private GameObject player;
	public GameObject basicArrow;
    public GameObject FastArrow;
	//public Texture2D cursorTexture;

	//Setup
	public bool firing;

	//Part of Osu Mechanic
	private float osuTime;
    public float osuTimeScale;

    public GameObject loaded;

	public void Start() {
        UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        player = GameObject.FindWithTag ("Player");
        firing = false;

    }

	public void Update() {
        //Currently Breaking here for some reason
        if (GameController != null) {
            if (GameController.playerIsFiring) {
                osuTime += osuTimeScale * Time.deltaTime;
            }
        }
    }

	public void SpawnArrow(GameObject arrow) {
		GameObject toSpawn = Instantiate (arrow, player.transform.position, player.transform.rotation, this.transform);
		//toSpawn.GetComponent<Arrow> ().spell = spell;
	}

    public void StartSpawnSequence()
    {
		UIController.Shooting();
        loaded = basicArrow;
        osuTime = 0;
    }

    public void EndSpawnSequence()
    {
		UIController.Release();
        SpawnArrow(loaded);
        osuTime = 0;
    }

    public float GetOsuTime() {
        return osuTime;
    }
}