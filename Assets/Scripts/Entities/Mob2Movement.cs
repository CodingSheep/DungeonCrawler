using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob2Movement : MonoBehaviour
{
	Transform player;
	NavMeshAgent nav;
	Rigidbody rb;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody> ();
		InvokeRepeating ("Jump", 0, 2f);
	}

	void Update()
	{
		transform.LookAt(player);
		nav.speed = 0;
		nav.acceleration = 0;
	}

	void Jump() {
		rb.AddForce (new Vector3(transform.forward.x*100, 1000, transform.forward.z*100));
	}

	IEnumerator JumpLogic()
	{
		float minWaitTime = 2;
		float maxWaitTime = 4;

		while(true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
			//Jump();
		}
	}

}