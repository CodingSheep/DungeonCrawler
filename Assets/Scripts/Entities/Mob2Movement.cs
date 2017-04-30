using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob2Movement : MonoBehaviour
{
	Transform player;
	NavMeshAgent nav;
	Rigidbody rb;
    Animator anim;
	public float jumpRate = 2f;
	public float jumpHeight = 1000f;

	void Awake()
	{
        anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody> ();
		InvokeRepeating ("Jump", 0, jumpRate);
	}

	void Update()
	{
		transform.LookAt(player);
	}

	void Jump() {
        anim.SetTrigger("Surround Attack");
		rb.AddForce (new Vector3(transform.forward.x*jumpHeight*1.8f, jumpHeight*0.7f, transform.forward.z*jumpHeight*1.8f));
	}

}
