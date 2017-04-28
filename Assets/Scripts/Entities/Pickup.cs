﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	Player player;

	public float minVal = 1;
	public float maxVal = 1;
	public enum pickupTypes
	{
		none = 0, speed = 1, arrowSpeed = 2, damage = 3, health = 4, maxHealth = 5
	}
	public pickupTypes pickupType;
	public float pickupValueOrMult = 1f; //value or multiplier for pickup to apply to player

	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();
	}
	
	void FixedUpdate () {
		//bobbing up and down movement can be added here
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			UseEffect ();
			Destroy (this.gameObject);
		}
	}

	void UseEffect() {
		switch (pickupType) {

		case pickupTypes.speed:
			player.speed *= pickupValueOrMult;
			break;
		case pickupTypes.arrowSpeed:
			player.arrowSpeed *= pickupValueOrMult;
			break;

		case pickupTypes.damage:
			player.arrowDmg *= pickupValueOrMult;
			break;

		case pickupTypes.health:
			if (player.health < player.maxHealth)
				player.health += (int)pickupValueOrMult;
			break;

		case pickupTypes.maxHealth:
			player.maxHealth += (int)pickupValueOrMult;
			player.health = player.maxHealth;
			break;
		}
	}
}

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	Player player;

	public bool randomVal = false;
	public float minVal = 1;
	public float maxVal = 1;
	public bool randomType = false;
	public enum pickupTypes
	{
		none = 0, speed = 1, arrowSpeed = 2, damage = 3, health = 4, maxHealth = 5
	}
	public pickupTypes pickupType;
	public float pickupValueOrMult = 1f; //value or multiplier for pickup to apply to player

	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();

		//  Random generator for multiplier values  //
		if (randomType) {
			pickupType = (pickupTypes)Random.Range (1, 6);
		}
		if ((pickupType == pickupTypes.speed || pickupType == pickupTypes.arrowSpeed || pickupType == pickupTypes.damage) && randomVal) {
			pickupValueOrMult = Random.Range (minVal, maxVal);
		}
	}
	
	void FixedUpdate () {
		//bobbing up and down movement can be added here
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			UseEffect ();
			Destroy (this.gameObject);
		}
	}

	void UseEffect() {
		switch (pickupType) {

		case pickupTypes.speed:
			player.speed *= pickupValueOrMult;
			break;
		case pickupTypes.arrowSpeed:
			player.arrowSpeed *= pickupValueOrMult;
			break;

		case pickupTypes.damage:
			player.arrowDmg *= pickupValueOrMult;
			break;

		case pickupTypes.health:
			if (player.health < player.maxHealth)
				player.health += (int)pickupValueOrMult;
			break;

		case pickupTypes.maxHealth:
			player.maxHealth += (int)pickupValueOrMult;
			player.health = player.maxHealth;
			break;
		}
	}
}


*/