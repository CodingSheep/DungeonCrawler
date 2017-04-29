using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1Movement : MonoBehaviour {
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	public GameObject MobCanvas;
	public GameObject MobTextPrefab;

	public float speed;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		nav.SetDestination(player.position);
		StabilizeCanvas ();
		if (Input.GetKey (KeyCode.T)) {
			DamageHit();
		}
	}

	void DamageHit(){

		/**
		 * Do health calculations with damage on health
		 * Give Health to DamageTextInit using ToString method
		 * */

		DamageTextInit ("50");

	}

	void DamageTextInit(string damage){

		//Sets up the object and rect
		GameObject Temp = Instantiate (MobTextPrefab) as GameObject;
		RectTransform TempRect = Temp.GetComponent<RectTransform> ();
		//sets parent and local positions
		Temp.transform.SetParent (transform.Find ("MobCanvas"));
		TempRect.transform.localPosition = MobTextPrefab.transform.localPosition;
		TempRect.transform.localScale = MobTextPrefab.transform.localScale;
		TempRect.transform.localRotation = MobTextPrefab.transform.localRotation;

		//sets the damage text and destroy in 1 second
		Temp.GetComponent<UnityEngine.UI.Text> ().text = damage;
		Destroy (Temp, 1);

	}

	//Stabilizes the canvas with respect to the camera because the player is moving
	void StabilizeCanvas(){

		float stable_y = -this.transform.rotation.y;

		//52.0f for the camera angle and stable_y to make up for rotation of the player
		MobCanvas.transform.eulerAngles = new Vector3 (52.0f, stable_y, 0.0f);


	}

}