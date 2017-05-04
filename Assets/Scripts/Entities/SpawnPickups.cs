using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour {
    /*! \class SpawnPickups
     * Spawns certain items
     */

	public float radius = 20.0f;
	private float timer = 0.0f;

	//For our Pickup list (We can add prefabs Directly from Unity)
	public List<Pickup> PrefabList = new List<Pickup>();

	void Update () {
		timer += UnityEngine.Time.deltaTime;

		//Spawns an item every 10 seconds
		if (timer >= 10.0) {
			//Picks a random
			int PrefabIndex = UnityEngine.Random.Range(0, PrefabList.Count);
			Instantiate (PrefabList[PrefabIndex], Random.insideUnitSphere * radius + transform.position, Random.rotation);

			/*
			//In case the item to spawn is below the ground. CURRENTLY A WIP
			if (PrefabList [PrefabIndex].transform.position.y < 1)
				PrefabList [PrefabIndex].transform.position.y = 1;
			*/

			//Reset the timer
			timer = 0.0f;
		}
	}
}
