using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	Player player;

	public bool random = false;
	public float speedMult = 1f;
	public float arrowSpeedMult = 1f;
	public float dmgMult = 1f;

	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();

		//  Random generator for multiplier values  //
		if (random) {
			switch ((int)Random.Range (0f, 2.99f)) {
			case 0:
				speedMult = Random.Range (1.25f, 1.75f);
				break;
			case 1:
				arrowSpeedMult = Random.Range (1.25f, 1.75f);
				break;
			case 2:
				dmgMult = Random.Range (1.25f, 1.75f);
				break;
			}
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
		player.speed *= speedMult;
		player.arrowSpeed *= arrowSpeedMult;
		player.arrowDmg *= dmgMult;
	}
}
