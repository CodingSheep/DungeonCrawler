using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public Spell spell = new Spell(true, 1, "Basic");
	public float speed = 40f;
	public float lifetime = 2f;

	void Start () {
		Invoke ("DestroySelf", lifetime);
	}
	
	void FixedUpdate () {
		transform.Translate (transform.forward * speed * Time.deltaTime);
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
