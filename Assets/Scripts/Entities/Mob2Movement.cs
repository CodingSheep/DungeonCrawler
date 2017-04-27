using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob2Movement : MonoBehaviour
{
	Transform player;
	NavMeshAgent nav;
	Rigidbody rb;

	public float jumpRate = 2f;
	public float jumpHeight = 1000f;

	void Awake()
	{
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
		rb.AddForce (new Vector3(transform.forward.x*jumpHeight*1.75f, jumpHeight, transform.forward.z*jumpHeight*1.75f));
	}

}