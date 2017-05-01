using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public List<GameObject> items;

	void Start () {
		Physics.IgnoreLayerCollision (9, 8);
		InvokeRepeating ("SpawnItem", 30f, 25f);
	}
	
	void Update () {
		
	}

	void SpawnItem() {
		int itemType = Random.Range (0, items.Count);
		GameObject toSpawn = Instantiate (items [itemType], transform.position, Quaternion.Euler(Vector3.right*20));
		toSpawn.GetComponent<Rigidbody> ().AddForce (Vector3.up * 1000);
		toSpawn.GetComponent<Rigidbody> ().AddForce (new Vector3 (Random.Range (-2f, 2f), 0, Random.Range (-2f, 2f)).normalized * 200);
	}
}
