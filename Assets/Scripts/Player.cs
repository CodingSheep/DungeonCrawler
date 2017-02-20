using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//This sets a default speed for how fast our player can move in any direction
	public float speed = 5.0f;

    private Vector3 deltamovement;
    private GameObject gamecontroller;

    //For future use.
    void Start()
    {
        gamecontroller = GameObject.FindGameObjectWithTag("GameController");
    }

    //Every Frame I believe
    void Update()
	{
        //Uses the default Unity Input object too manage player input. This allows for multiple platforms, and easy customization in the future.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        deltamovement = transform.position + speed * (new Vector3(h, 0, v)).normalized * Time.deltaTime; //Vector of movement direction * time since last called.
        transform.position = deltamovement;
    }

}
