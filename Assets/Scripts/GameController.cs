using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public GameObject osuCircles;


	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {



			Instantiate (osuCircles, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
			OsuCircle this_circle = osuCircles.GetComponent<OsuCircle> ();
			this_circle.cluster (4);
		}
	
	}
}
