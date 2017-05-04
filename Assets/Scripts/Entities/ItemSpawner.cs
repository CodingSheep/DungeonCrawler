using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    /*! \class ItemSpawner
     * Spawns items perodically. Based of score
     */
	public List<GameObject> items; //!< list of all items to spawn in this spawner

    /*!
     * Starts Spawning sequence in repitition and also sets lays to ignore
     */
	void Start () {
		Physics.IgnoreLayerCollision (9, 8);
		InvokeRepeating ("SpawnItem", 30f, 25f);
	}

    /*!
     * Spawns a random item in on the spawner
     */
	void SpawnItem() {
		int itemType = Random.Range (0, items.Count);
		GameObject toSpawn = Instantiate (items [itemType], transform.position, Quaternion.Euler(Vector3.right*20));
        //!< @note adds a random direction to the object so it's not stuck in the middle of the well.
		toSpawn.GetComponent<Rigidbody> ().AddForce (Vector3.up * 1000);
		toSpawn.GetComponent<Rigidbody> ().AddForce (new Vector3 (Random.Range (-2f, 2f), 0, Random.Range (-2f, 2f)).normalized * 200);
	}
}
