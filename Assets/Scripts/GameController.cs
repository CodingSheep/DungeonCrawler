using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public GameObject osuCircles;
    private SpellController spellController;

	void Start () {
        spellController = GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>();  

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {
			Instantiate (osuCircles, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
			OsuCircle this_circle = osuCircles.GetComponent<OsuCircle> ();
			//this_circle.cluster (4);
		}

        //Basic arrow shot (right click)
        if (Input.GetButtonUp("Fire2"))
        {
            //if (finalHit == null)
            spellController.SpawnArrow(spellController.basicArrow);


            /*Other input events can be set up here to spawn arrows based on the final osu
			circle hit*/
            //else
            //SpawnArrow(finalHit.spell);
        }
        //TODO: Fix this part
        if (Input.GetButtonUp("Fire1"))
        {
            //if (finalHit == null)
            spellController.SpawnArrow(spellController.FastArrow);


            /*Other input events can be set up here to spawn arrows based on the final osu
			circle hit*/
            //else
            //SpawnArrow(finalHit.spell);
        }

    }
}
