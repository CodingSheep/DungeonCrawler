﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {
    private UIController UIController;

	private GameObject player;
	public GameObject basicArrow;
    public GameObject FastArrow;
	//public Texture2D cursorTexture;

	//Setup
	public bool firing;
	private bool settingUp = true;

	//Part of Osu Mechanic
	private float osuTime;
    public float osuTimeScale;

    public GameObject loaded;

	//Spell List!
	public List<Spell> allSpells = new List<Spell>();
	public List<Spell> unlockedSpells = new List<Spell>();

	//UI Wheel
	public int div;

    //Spells!
	public Spell basic = new Spell(true, 1.0, "Basic", 40f);
	public Spell fire = new Spell(true, 5.0, "Fire", 40f);
	public Spell lightning = new Spell(false, 5.0, "Lightning", 40f);
	public Spell earth = new Spell(false, 5.0, "Earth", 40f);
	public Spell ice = new Spell(true, 5.0, "Ice", 40f);

	//private Vector2 hotSpot = Vector2.zero;

	public void Start() {
        UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
		player = GameObject.FindWithTag ("Player");
        firing = false;

    }

	public void Update() {
        if (firing) {
            osuTime += osuTimeScale*Time.deltaTime;
            //Debug.Log(osuTime);
        }
    }

	//This is where we all all possible spells to a regular spell queue.
	public void setup () {
		/*
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
		*/

		//osuTime = 0;

		//Spell Setup
		allSpells.Add(fire);
		allSpells.Add(lightning);
		allSpells.Add(earth);
		allSpells.Add(ice);

		//Adds unlocked spells to the list
		for (int i = 0; i < allSpells.Count; i++)
			if (allSpells [i].unlocked)
				unlockedSpells.Add (allSpells [i]);

		//UI Wheel Setup. We're doing it in code, baby!
		int div = 360 / unlockedSpells.Count;
	}

    internal void SpawnArrow(object fastArrow)
    {
        throw new NotImplementedException();
    }

    //WIP
    /*
    public void Osu () {
		//This is where the initial circles are made
		if (settingUp) {
			//INSERT CODE FOR SPAWNING THE WHEEL FROM PREFABS
			//Dont worry, as soon as we choose a spell, settingUp WILL become false, pushing us straight into the Osu mechanic.

			//This is a temporary thing. Change this to UI when we get there:
			settingUp = false;
		} else if (osuTime < 3) {
			//We need it so that the spell is chosen and THEN the mechanics start. Only now would stillGoing become true.
			//The Osu mechanic, I think, should be entirely UI based, and should keep going until you fail or 3 seconds are up for
			//  the sake of NOT having to keep doing it for (INSERT AMOUNT OF TIME) on end.
		} else if (osuTime >= 3) {
			//We finished mechanic. Time to reset
			osuTime = 0;
			settingUp = true;
		}
	}
    */
	public void SpawnArrow(GameObject arrow) {
		GameObject toSpawn = Instantiate (arrow, player.transform.position, player.transform.rotation, this.transform);
		//toSpawn.GetComponent<Arrow> ().spell = spell;
	}

    public void StartSpawnSequence()
    {
        UIController.SetIsShooting(true);
        loaded = basicArrow;
        firing = true;
        osuTime = 0;
    }

    public void EndSpawnSequence()
    {
        UIController.SetIsShooting(false);
        SpawnArrow(loaded);
        firing = false;
        osuTime = 0;
    }

    public float GetOsuTime() {
        return osuTime;
    }
}