using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1Movement : MonoBehaviour {
    /*! \class Mob1Movement
     * Basic mob class
     * This mob follows the player directly
     */ 
	Transform player; //!< Player's current position
	UnityEngine.AI.NavMeshAgent nav; //<! Nav mesh of the land to use Unity's Default pathing AI
	public GameObject MobCanvas; //<! Damage text Canvas
	public GameObject MobTextPrefab; //<! Damage Text

	public float speed; //!< speed which the mob approaches the player

	/*!
     * Sets member values
     */
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	/*!
     * Updates all members and checks for test "T" input for damage
     */
	void Update () {
		nav.SetDestination(player.position);
		StabilizeCanvas ();
		if (Input.GetKey (KeyCode.T)) {
			DamageHit();
		}
	}
    /*!
    * Do health calculations with damage on health
    * Give Health to DamageTextInit using ToString method
    */
    void DamageHit(){
		DamageTextInit ("50");
	}

    /*!
     * Creates Damage text on hit
     */
	void DamageTextInit(string damage){

		//Sets up the object and rect
		GameObject Temp = Instantiate (MobTextPrefab) as GameObject;
		RectTransform TempRect = Temp.GetComponent<RectTransform> ();
		//sets parent and local positions
		Temp.transform.SetParent (transform.Find ("MobCanvas"));
		TempRect.transform.localPosition = MobTextPrefab.transform.localPosition;
		TempRect.transform.localScale = MobTextPrefab.transform.localScale;
		TempRect.transform.localRotation = MobTextPrefab.transform.localRotation;

		//sets the damage text and destroy in 1 second
		Temp.GetComponent<UnityEngine.UI.Text> ().text = damage;
		Destroy (Temp, 1);

	}

    /*!
     * Smooths the damage text's canvas to decrease jitter
     */
	//!< Stabilizes the canvas with respect to the camera because the player is moving
	void StabilizeCanvas(){

		float stable_y = -this.transform.rotation.y;

		//! @note 52.0f for the camera angle and stable_y to make up for rotation of the player
		MobCanvas.transform.eulerAngles = new Vector3 (52.0f, stable_y, 0.0f);


	}

}