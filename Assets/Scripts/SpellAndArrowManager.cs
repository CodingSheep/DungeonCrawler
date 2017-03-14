using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
	public bool unlocked;
	public double dmgMult;
	public string name;
	public float speedMult;

	public Spell(bool un, double dm, string na, float sm)
	{
		unlocked = un;
		dmgMult = dm;
		name = na;
		speedMult = sm;
	}
}

public class SpellAndArrowManager : MonoBehaviour {

	//OsuMechanic
	private OsuMechanic osu;

	//GameObjects
	private GameObject player;
	public GameObject basicArrow;
	//public Texture2D cursorTexture;

	//Part of Osu Mechanic
	private bool runningOsu;

	//Spell Lists!
	private List<Spell> allSpells = new List<Spell>();
	private List<Spell> unlockedSpells = new List<Spell>();

	//UI Wheel Setup. Must be initialized here as the lists are private
	public int div;

	//Spells!
	private Spell basic = new Spell(true, 1.0, "Basic", 40f);
	private Spell fire = new Spell(true, 1.0, "Fire", 40f);
	private Spell lightning = new Spell(false, 1.0, "Lightning", 40f);
	private Spell earth = new Spell(false, 1.0, "Earth", 40f);
	private Spell ice = new Spell(true, 1.0, "Ice", 40f);
	private Spell toUse;

	//private Vector2 hotSpot = Vector2.zero;

	public void Start() {
		player = GameObject.FindWithTag ("Player");
	}

	//I don't think we need this Update as this is an expansion to Player (where all the updates are)
	public void Update() {
		//Basic arrow shot (right click)
		if (Input.GetButtonUp ("Fire2")) {
			//if (finalHit == null)
			//SpawnArrow (basic);


			/*Other input events can be set up here to spawn arrows based on the final osu
			circle hit*/
			//else
			//SpawnArrow(finalHit.spell);
		}
	}

	//This is where we all all possible spells to a regular spell queue.
	public void setup () {
		/*
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
		*/

		osu.osuTime = 0;
		runningOsu = false;

		//Spell Setup
		allSpells.Add(fire);
		allSpells.Add(lightning);
		allSpells.Add(earth);
		allSpells.Add(ice);

		//Adds unlocked spells to the list
		for (int i = 0; i < allSpells.Count; i++)
			if (allSpells [i].unlocked)
				unlockedSpells.Add (allSpells [i]);

		//UI Wheel Setup. We're doing it in code!
		div = 360 / unlockedSpells.Count;
	}

	//WIP
	public void toOsu () {
		//This is where the initial circles are made
		if (osu.settingUp) {

			//This will kickstart the Osu Mechanic. Most everything regarding it is wrapped up in OsuMechanic.cs
			//The Spell type will be pulled from a variable in OsuMechanic and the dmg multiplier will be from the osuTime.
			osu.OsuSetup ();

		} else if (osu.osuTime >= 3 || !osu.stillGoing){
			//We finished mechanic. Time to reset and spawn the arrow with our prefab.
			//Note that this will go only if we failed to click a circle or our time is up.

			//Set up which spell to do based on the button we initially pressed
			switch (osu.spellName) {
			case "Fire":
				toUse = fire;
				break;
			case "Ice":
				toUse = ice;
				break;
			case "Earth":
				toUse = earth;
				break;
			case "Lightning":
				toUse = lightning;
				break;
			}

			//Sets up a Damage Multiplier to our spell based on our OsuTime
			if (osu.osuTime < 1.5)
				toUse.dmgMult = 1.0;
			else if (osu.osuTime < 3)
				toUse.dmgMult = 2.0;
			else
				toUse.dmgMult = 3.0;

			//Now we spawn our arrow with the set dmgMult and Spell.
			SpawnArrow (toUse);

			//Reset for the next arrow
			osu.osuTime = 0;
			osu.settingUp = true;
			runningOsu = false;
		}

		//If it doesnt satisfy either of the above conditions, then it is in the Osu Mechanic itself and we dont want to do anything.
	}

	//WIP maybe?
	public void SpawnArrow(Spell spell) {
		//Spawns Arrow with the spell defined earlier.
		GameObject toSpawn = Instantiate (basicArrow, player.transform.position, player.transform.rotation, this.transform);
		toSpawn.GetComponent<Arrow>().spell = spell;
	}
}
