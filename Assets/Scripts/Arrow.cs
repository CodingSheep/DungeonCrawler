using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public Spell spell = new Spell(true, 1, "Basic", 40f);
	public float speed = 40f;
	public float lifetime = 2f;
	public GameObject model;

	void Start () {
		Invoke ("DestroySelf", lifetime);
		speed = spell.speed;
		model = Resources.Load ("Models/" + spell.name) as GameObject;
		if (model != null) {Debug.Log ("model loaded");}
		this.GetComponentInChildren<MeshFilter> ().mesh = model.GetComponent<MeshFilter> ().sharedMesh;
	}
	
	void FixedUpdate () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy") {
			/*Enemy hit sequence (do damage, apply status effects, kill arrow)*/
			//col.gameObject.GetComponent<EnemyHealth>().health -= spell.dmg;
			DestroySelf();
		} else if (col.gameObject.tag == "World") {
			DestroySelf();
		}
	}

	void DestroySelf() {
		Destroy(this.gameObject);
	}
}
