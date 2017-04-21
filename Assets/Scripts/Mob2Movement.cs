using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob2Movement : MonoBehaviour
{
    Transform player;
    //UnityEngine.AI.NavMeshAgent nav;
    Rigidbody rb;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Jump", Random.Range(1f,2f), Random.Range(2f,3f));
    }

    void Update()
    {
        transform.LookAt(player);
        //nav.speed = 0;
        //nav.acceleration = 0;
        //nav.SetDestination(player.position);
    }

    void Jump()
    {
        rb.AddForce(new Vector3(transform.forward.x*Random.Range(400f, 800f), Random.Range(300f, 350f), transform.forward.z* Random.Range(400f, 800f)));
    }

/*    IEnumerator JumpLogic()
    {
        float minWaitTime = 2;
        float maxWaitTime = 4;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            //Jump();
        }
    }*/

}