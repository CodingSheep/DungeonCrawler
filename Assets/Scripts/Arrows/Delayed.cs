using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayed : Arrow {
    public GameObject BasicArrow;
    private Arrow BaseArrow;

    public float spawntimer;
    private float spawntime;
    private Vector3 InitialPosition;
    // Use this for initialization
    new void Start() {
        BaseArrow = base.gameObject.GetComponent<Arrow>();
        BaseArrow.Start();
        spawntime = Time.time + spawntimer;
        base.player = GameObject.FindGameObjectWithTag("Player");
        InitialPosition = transform.position;
        //Debug.Log("Fast Arrow");
    }
    // Update is called once per frame
    new void FixedUpdate() {
        BaseArrow.FixedUpdate();
        BaseArrow.speedMult += BaseArrow.speedMult*Time.deltaTime;
        //Debug.Log(base.speedMult);
        //Debug.Log(InitialPosition);
        if(Time.time > spawntime) {
            spawntime = spawntimer + Time.time;
            GameObject toSpawn = Instantiate(BasicArrow, InitialPosition, transform.rotation);
        }
        //Debug.Log(base.GetComponent<Arrow>().player);
    }
}
