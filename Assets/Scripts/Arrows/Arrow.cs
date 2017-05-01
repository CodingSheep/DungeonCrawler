using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float speedMult;
	public float lifetime = 2f;
	public GameObject model;
	public Player player = null;
    public AudioSource source;

	public enum arrowDmgTypes
	{
		basic = 0, fire = 1, ice = 2, slow = 3
	}
	public arrowDmgTypes arrowDmgType = arrowDmgTypes.basic;

	public void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Invoke ("DestroySelf", lifetime);
        source = GetComponent<AudioSource>();
        source.Play();
        Debug.Log("Playing");
    }

    public void FixedUpdate(){
		transform.Translate(Vector3.forward * speedMult * player.arrowSpeed);
    }



    void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy") {
			MobHealth enemy = col.gameObject.GetComponent<MobHealth> ();

			switch (arrowDmgType) {
			case arrowDmgTypes.basic:
				enemy.DoDamage (player.arrowDmg);
				break;
			case arrowDmgTypes.fire:
				enemy.ApplyBurn (player.arrowDmg, player.burnAmount);
				break;
			case arrowDmgTypes.ice:
				enemy.ApplyFreeze (player.arrowDmg, player.freezeTime);
				break;
			case arrowDmgTypes.slow:
				enemy.ApplySlow (player.arrowDmg, player.slowMult);
				break;
			}
			DestroySelf();
		} else if (col.gameObject.tag == "World") {
			DestroySelf();
		}
	}

	void DestroySelf() {
		Destroy(this.gameObject);
	}
}
