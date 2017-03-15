using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob2Movement : MonoBehaviour
{
    Transform player;


    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        //nav.speed = 0;
        //nav.acceleration = 0;
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
