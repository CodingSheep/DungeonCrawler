using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {


    private Vector3 offset;

    //Sets up player
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        offset = this.GetComponent<Transform>().position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
    }

}
