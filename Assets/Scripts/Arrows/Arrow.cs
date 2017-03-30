using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public Spell spell = new Spell(true, 1, "Basic", 1f);
	public float speedMult;
	public float lifetime = 2f;
	public GameObject model;
	public GameObject player = null;
    public bool Exists = false;

	public void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Invoke ("DestroySelf", lifetime);
		//speedMult = spell.speedMult;
		model = Resources.Load ("Models/" + spell.name) as GameObject;
		//if (model != null) {Debug.Log ("model loaded");}
		this.GetComponentInChildren<MeshFilter> ().mesh = model.GetComponent<MeshFilter> ().sharedMesh;
        Exists = true;
    }

    public void FixedUpdate()
    {
        if(Exists)
        {
            //player = GameObject.FindGameObjectWithTag("Player");
            transform.Translate(Vector3.forward * speedMult * player.GetComponent<Player>().arrowSpeed);
        }
        else{
            Start();
        }
    }

    void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy") {
			/*Enemy hit sequence (do damage, apply status effects, kill arrow)*/
			//col.gameObject.GetComponent<EnemyHealth>().health -= player.arrowDmg * spell.dmgMult;
			DestroySelf();
		} else if (col.gameObject.tag == "World") {
			DestroySelf();
		}
	}

	void DestroySelf() {
		Destroy(this.gameObject);
	}
}
