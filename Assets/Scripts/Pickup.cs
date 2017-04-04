using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	Player player;

	public bool randomVal = false;
	public bool randomType = false;
	public enum pickupTypes
	{
		none = 0, speed = 1, arrowSpeed = 2, damage = 3, health = 4, maxHealth = 5
	}
	public pickupTypes pickupType;
	public float pickupValueOrMult = 1f; //value or multiplier for pickup to apply to player
	/*public float speedMult = 1f;
	public float arrowSpeedMult = 1f;
	public float dmgMult = 1f;*/

	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();

		//  Random generator for multiplier values  //
		if (randomType) {
			pickupType = (pickupTypes)Random.Range (1, 6);
		}
		if ((pickupType == pickupTypes.speed || pickupType == pickupTypes.arrowSpeed || pickupType == pickupTypes.damage) && randomVal) {
			pickupValueOrMult = Random.Range (1.25f, 1.75f);
		}
			/*switch ((int)Random.Range (0f, 2.99f)) {
			case 0:
				speedMult = Random.Range (1.25f, 1.75f);
				break;
			case 1:
				arrowSpeedMult = Random.Range (1.25f, 1.75f);
				break;
			case 2:
				dmgMult = Random.Range (1.25f, 1.75f);
				break;
			}*/

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
