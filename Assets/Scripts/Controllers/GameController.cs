using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public GameObject osuCircles;
    private SpellController spellController;
    public bool playerIsFiring;
	void Start () {
        spellController = GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>();
        playerIsFiring = false;

    }

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {
			Instantiate (osuCircles, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
			OsuCircle this_circle = osuCircles.GetComponent<OsuCircle> ();
			//this_circle.cluster (4);
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
