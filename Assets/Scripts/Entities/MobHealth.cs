using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MobHealth : MonoBehaviour {

    /*! \class MobHealth
     * Specific class for controlling Mob Health and status effects
     * @note this Should not be a gameobject, but instead just a component attached to some gameobjects
     */

	public float health = 10f; //!< Base health
	public float curHealth; //!< Health at any given moment
	private Mob2Movement movement2; //!< Movement sceme for mob2
	private NavMeshAgent nav; //!< Nav mesh of the land to use Unity's Default pathing AI
    private float navSpeed; //!< Speed 
	private bool alreadySlowed = false; //!< Bool for speed

	public Texture2D HpBarTexture; //!< HPBar texture
	public Texture2D HpBackTexture;
	private float hpBarLength; //!< Interacts with UI canvas to change depending on remaining HP
	private Vector3 target; //!< Target the mobthat's attached is moving towards
      
	public GameObject damageText; //!< Damage to show

	private UIController uic; //!< UIController

    /*!
     * Instantiates member values and distinguishes between the type of mob
     */
	void Start () {
		
		//for jumper mobs
		if (GetComponent<Mob2Movement>() != null)
			movement2 = GetComponent<Mob2Movement> ();
		//for simple mover mobs
		else if (GetComponent<NavMeshAgent>() != null)
			nav = GetComponent<NavMeshAgent>();
	
		uic = GameObject.FindWithTag ("UIController").GetComponent<UIController> ();

		curHealth = health;
	}

    /*!
     * Update position of the Healthbar to be slightly above the mob associated with this object
     */
	void Update () {
		if (curHealth <= 0)
			Destroy (this.gameObject);

		hpBarLength = ((float)curHealth / health) * 100;

		target = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
		target.y = Screen.height - (target.y + 1);
	}
    /*!
     * shows damage upon getting hit with an arrow above the mob
     */
	void InitDamageText(string str) {
		GameObject toSpawn = Instantiate (damageText) as GameObject;
		RectTransform rect = toSpawn.GetComponent<RectTransform> ();
		toSpawn.transform.SetParent(transform.FindChild("MobCanvas"));
		toSpawn.transform.localPosition = damageText.transform.localPosition;
		toSpawn.transform.localScale = damageText.transform.localScale;
		toSpawn.transform.localRotation = damageText.transform.localRotation;
		toSpawn.GetComponent<Text> ().text = str;

		toSpawn.GetComponent<Animator> ().SetTrigger ("Hit");
		Destroy (toSpawn.gameObject, 2);
	}

    /*!
     * Function to handle status effect like arrows
     * @param dmg is Incoming damage
     */
	public void DoDamage(float dmg) {
		InitDamageText (dmg.ToString ());
		if (curHealth <= dmg) {
			uic.UpdateScore (1);
			Destroy (this.gameObject);
		} else {
			curHealth -= dmg;
		}
	}

    /*!
     * Function to start a "Burn" like function to a mob using corrutines
     * @param dmg Initial damage
     * @param burns is burn per cycle
     */
	public void StartBurn(float dmg, int burns) {
		StartCoroutine(ApplyBurn (dmg, burns));
	}

    /*!
     * IEnumerator to apply damage continiously... the "burning" effect
     * @param dmg initial damage
     * @param burnsLeft how many loops to go through before expiring
     */
	public IEnumerator ApplyBurn(float dmg, int burnsLeft) {
		yield return new WaitForSeconds (1); //one second burn rate
		BurnEffect (dmg);
		Debug.Log ("Burning");
		if (burnsLeft > 0) {
			StartCoroutine (ApplyBurn (dmg, burnsLeft - 1)); //call burn again with 1 less repeat
		}
	}

	/*!
     * Applies Freeze effect to mob.
     * @param dmg initial Damage
     * @param time duration of freeze
     */
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
    /*!
     * Applies a slowing effect to the mob
     * @param dmg initial damage
     * @param slowMult the change to the speed multiplier of the mob
     */
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
    /*!
     * Undoes the Freeze effect, called at freeze expiration
     */
	void Unfreeze() {
		if (nav != null)
			nav.speed = navSpeed;
		else if (movement2 != null)
			movement2.enabled = true;
	}

    /*!
     * Applies burn damage, called everytick
     * @param the amount of damage to do (burn damage)
     */
	void BurnEffect(float dmg) {
		//audioSource.Play(burnSound);
		DoDamage(dmg);
	}

	//!<Test for Health Bar
	void OnGUI() {
		if (!uic.isGameOver) {
			GUI.DrawTexture (new Rect (target.x - 50, target.y - 50, hpBarLength, 10), HpBackTexture);
			GUI.DrawTexture (new Rect (target.x - 50, target.y - 50, hpBarLength, 10), HpBarTexture);
		}
	}
}
