using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob2Movement : MonoBehaviour
{
    /*! \class Mob2Movement
     * This mob Occasionally jumps at the player
     */
    Transform player; //!< Player position/transform
	NavMeshAgent nav; //<! Nav mesh of the land to use Unity's Default pathing AI
    Rigidbody rb; //<! Rigidbody to handle physics using Unity's Physics engine and forces
    Animator anim; //<! Animator object to handle specific jump animation
	public float jumpRate = 2f; //!< Frequency of jumping
	public float jumpHeight = 1000f; //!< force of jumping

    /*!
     * Sets member values
     */
    void Awake()
	{
        anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody> ();
		InvokeRepeating ("Jump", 1f, jumpRate);
	}

    /*!
     * Constantly rotate to look at player
     * @note since this mob only moves with jumps, this is used.
     */
	void Update()
	{
		transform.LookAt(player);
	}

    /*!
     * Unity Physics engine calculation to jump at the player's current location
     */
	void Jump() {
        anim.SetTrigger("Surround Attack"); //! Animation for Surround attack @note since it looks neat
        rb.AddForce (new Vector3(transform.forward.x*jumpHeight*1.8f, jumpHeight*0.7f, transform.forward.z*jumpHeight*1.8f));
        
    }

}
