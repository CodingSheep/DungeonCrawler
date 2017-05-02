using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobHealth : MonoBehaviour {

	public float health = 10f;
	public float curHealth;
	private Mob2Movement movement2;
	private NavMeshAgent nav;
	private float navSpeed;
	private bool alreadySlowed = false;

	public Texture2D HpBarTexture;
	public Texture2D HpBackTexture;
	private float hpBarLength;
	private Vector3 target;

	void Start () {
		
		//for jumper mobs
		if (GetComponent<Mob2Movement>() != null)
			movement2 = GetComponent<Mob2Movement> ();
		//for simple mover mobs
		else if (GetComponent<NavMeshAgent>() != null)
			nav = GetComponent<NavMeshAgent>();
	
		curHealth = health;
	}

	void Update () {
		if (curHealth <= 0)
			Destroy (this.gameObject);

		hpBarLength = ((float)curHealth / health) * 100;

		target = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
		target.y = Screen.height - (target.y + 1);
	}

	//
	//--------------------------------------------------------
	// STATUS EFFECTS
	//--------------------------------------------------------
	//

	public void DoDamage(float dmg) {
		health -= dmg;
	}

	//--------------------------------------------------------

	public IEnumerator ApplyBurn(float dmg, int burnsLeft) {
		yield return new WaitForSeconds (.5f); //half second burn rate
		BurnEffect (dmg);
		if (burnsLeft > 0) {
			StartCoroutine (ApplyBurn (dmg, burnsLeft - 1)); //call burn again with 1 less repeat
		}
	}

	//--------------------------------------------------------

	public void ApplyFreeze(float dmg, float time) {
		/*audioSource.Play(freezeSound);*/
		DoDamage (dmg);

		//for simple movement mobs, zero nav speed for freeze effect
		if (nav != null) {
			navSpeed = nav.speed;
			nav.speed = 0;
		}
		//for jumper mobs, disable movement script
		else if (movement2 != null)
			movement2.enabled = false;
		
		Invoke ("Unfreeze", time);
	}

	//--------------------------------------------------------

	public void ApplySlow(float dmg, float slowMult) {
		/*audioSource.play(slowSound)*/
		DoDamage (dmg);

		if (!alreadySlowed) {
			alreadySlowed = true;

			//for simple movement mobs, slow nav speed for slow effect
			if (nav != null) {
				nav.speed = nav.speed / slowMult;
			}
			//for jumper mobs, lower jump rate
			else if (movement2 != null)
				movement2.jumpRate = movement2.jumpRate / slowMult;
		}
	}

	//--------------------------------------------------------

	void Unfreeze() {
		if (nav != null)
			nav.speed = navSpeed;
		else if (movement2 != null)
			movement2.enabled = true;
	}

	void BurnEffect(float dmg) {
		//audioSource.Play(burnSound);
		DoDamage(dmg);
	}

	//--------------------------------------------------------

	//Test for Health Bar
	void OnGUI() {
		GUI.DrawTexture(new Rect(target.x - 50, target.y - 50, hpBarLength, 10), HpBackTexture);
		GUI.DrawTexture(new Rect(target.x - 50, target.y - 50, hpBarLength, 10), HpBarTexture);
	}

	//--------------------------------------------------------
}
