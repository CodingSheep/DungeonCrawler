using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//This sets a default speed for how fast our player can move in any direction
	public float speed = 5.0f;

	//Every Frame I believe
	void Update()
	{
		Movement();
	}

	void Movement()
	{
		//Im very sure this bit is obvious, though I will explain the Time.deltaTime.
		//Time.deltaTime is basically the time it took to finish the last frame
		//It's used with speed to basically say "I want to move 5 meters per second, not 5 meters per frame"
		if (Input.GetKey (KeyCode.W)) 
		{
			Debug.Log ("Forward!");
			this.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			Debug.Log ("Backward!");
			this.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			Debug.Log ("Left!");
			this.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			Debug.Log ("Right!");
			this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
		}
	}
}
