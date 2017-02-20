using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	//Sets up player
	public Transform player = null;
	public Transform target = null;

	public Vector3 speed = new Vector3(4.0f, 0.0f, 4.0f);
	public Vector3 nextPosition = Vector3.zero;

	void Start()
	{
		this.transform.LookAt (player.position);
	}

	void LateUpdate()
	{
		nextPosition.x = target.position.x;
		nextPosition.y = target.position.y;
		nextPosition.z = target.position.z;

		/*
		nextPosition.x = Mathf.Lerp(this.transform.position.x, target.position.x, speed.x * Time.deltaTime);
		nextPosition.y = Mathf.Lerp(this.transform.position.y, target.position.y, speed.y * Time.deltaTime);
		nextPosition.z = Mathf.Lerp(this.transform.position.z, target.position.z, speed.z * Time.deltaTime);
		*/


		this.transform.position = nextPosition;
		this.transform.LookAt (player.position);
	}
}
