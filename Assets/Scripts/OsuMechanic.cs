using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsuMechanic : MonoBehaviour {

	//Steps:
	//  1. Spawn Circles every div degrees starting from top
	//  2. Clicking one would set stillGoing to true and settingUp to false.
	//  3. Circles will spawn randomly along the screen in quick succession (Limit to three?)
	//  4. The Circles will despawn after every .3 to .4 seconds to acount for human avg response time of 0.25 (Adjustable)
	//  5. The Circles will get spawned faster depending on OsuTime
	//  6. After 3 seconds, NO MORE SPAWNING
	//  7.1. Regardless of when the user ends, we need to set the user up with the spell to fire as well as a dmg multiplier.
	//  7.2. Maybe the dmg mult could be based on osuTime (x1 if clicked, x2 after 1.5 seconds, and x3 if full 3 seconds)?

	private bool canWeOsu = false;
	private float circleTimer;

	public float osuTime;
	public bool settingUp;
	public bool stillGoing;
	public string spellName;

	//Spawns Initial Selection Wheel
	public void OsuSetup () {

		//THIS IS WHERE WE WILL SPAWN THE INITIAL UI WHEEL FROM PREFABS
		//This will set the spellName to pass to the SpellAndArrowManager to set up the arrows

		stillGoing = true;
		settingUp = false;

		OsuStart ();
	}

	//Starts the Osu Mechanic
	private void OsuStart () {
		canWeOsu = true;
		circleTimer = 0;
	}

	//Stops the OsuMechanic
	private void OsuStop () {
		canWeOsu = false;
		stillGoing = false;
		settingUp = true;
	}

	public void Osu () {
		//Random Spawning
		//Will keep going while we can Osu!

		//Keeps track of time. SpellAndArrowManager handles the osuTime stop thing
		osuTime += Time.deltaTime;
		circleTimer += Time.deltaTime;

		//Maybe it would be a good idea to keep track of the number of circles on screen so that there are no more than
		//  a certain number at any given time

		if (osuTime < 1 && circleTimer >= 0.2) {
			circleTimer = 0;
			//Instansiate Circle in random spot
		} else if (osuTime < 2 && circleTimer >= 0.17) {
			circleTimer = 0;
			//Faster Circle Spawning by .03 seconds. Should still be noticible
		} else if (circleTimer >= 0.15) {
			circleTimer = 0;
			//Fastest the circles will get
		}

		if (osuTime >= 3)
			OsuStop ();
	}

	// Update is called once per frame
	void Update () {
		if(canWeOsu)
			Osu ();
	}
}
