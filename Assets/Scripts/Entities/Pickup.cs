using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	Player player;

	public float minVal = 1.1f;
	public float maxVal = 1.4f;
	public bool randomType;
	public bool randomVal = true;
	public enum pickupTypes
	{
		none = 0, speed = 1, arrowSpeed = 2, damage = 3, health = 4, maxHealth = 5
	}
	public pickupTypes pickupType;
	public float pickupValueOrMult = 1f; //value or multiplier for pickup to apply to player

	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();
		if (randomType) {
			pickupType = (pickupTypes)Random.Range (1, 5);
		}
		if (randomVal) {
			pickupValueOrMult = Random.Range (minVal, maxVal);
		}
	}
	
	void FixedUpdate () {
		if (GetComponent<SphereCollider> ().isTrigger) {
			transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 200 * Time.deltaTime, transform.rotation.eulerAngles.z));
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ground") {
			GetComponent<Rigidbody> ().isKinematic = true;
			GetComponent<SphereCollider> ().isTrigger = true;
		}
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