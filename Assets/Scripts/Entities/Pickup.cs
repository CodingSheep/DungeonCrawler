using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    /* \class Pickup
     * Class that handles Pickupable items. 
     * @note Prefab object
     */

	Player player; //!< Player object

	public float minVal = 1.1f; //!< value the object adds lower bound
	public float maxVal = 1.4f; //!< Value the object adds upper bound
	public bool randomType; //!< type of buff
	public bool randomVal = true;
	public enum pickupTypes //!< \enum kinds of buffs availble 
	{
		none = 0, speed = 1, arrowSpeed = 2, damage = 3, health = 4, maxHealth = 5
	}
	public pickupTypes pickupType; //!< the set pickup buff
	public float pickupValueOrMult = 1f; //!< value or multiplier for pickup to apply to player

    /*!
     * Instantiates member values and assigns pickup type (randomly)
     */
	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();
		if (randomType) {
			pickupType = (pickupTypes)Random.Range (1, 5);
		}
		if (randomVal) {
			pickupValueOrMult = Random.Range (minVal, maxVal);
		}
	}
	
    /*!
     * slowly rotates the object
     */
	void FixedUpdate () {
		if (GetComponent<SphereCollider> ().isTrigger) {
			transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 200 * Time.deltaTime, transform.rotation.eulerAngles.z));
		}
	}

    /*!
     * Handels collision events, once it collides with the ground the Rigidbody should be set to Kinematic and not move
     * @param col is the oppisite collider
     */
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ground") {
			GetComponent<Rigidbody> ().isKinematic = true;
			GetComponent<SphereCollider> ().isTrigger = true;
		}
	}

    /*!
     * Handels collision events where an object walks "into" the collider
     * If the collider is the player, the player will pick up the item
     * @param col is the coliding object's collider
     */
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			UseEffect ();
			Destroy (this.gameObject);
		}
	}

    /*!
     * handels how different types of pickups are set
     */
	void UseEffect() {
		switch (pickupType) {

		case pickupTypes.speed:
			player.speed *= pickupValueOrMult;
			break;
		case pickupTypes.arrowSpeed:
			player.arrowSpeed *= pickupValueOrMult;
			break;

		case pickupTypes.damage:
			player.arrowDmg *= pickupValueOrMult;
			break;

		case pickupTypes.health:
			if (player.health < player.maxHealth)
				player.health += (int)pickupValueOrMult;
			break;

		case pickupTypes.maxHealth:
			player.maxHealth += (int)pickupValueOrMult;
			player.health = player.maxHealth;
			break;
		}
	}
}
