using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayed : Arrow {
    /*! \class Delayed
     *  Delayed arrow shoots one arrow, then spawns more basic arrows in the same direction for a set duration.
     *  @note Death of this arrow type is managed by the parent class
     *  @note Prefab class
     */
    public GameObject BasicArrow; //!< Gameobject to be instantiate. In this case the BasicArrow prefab.
    private Arrow BaseArrow; //!< BaseArrow Component


    public float spawntimer; //!< Set how long the spawning will continue for.
    private float spawntime; //!< float to keep track of current time in gameworld.
    private Vector3 InitialPosition; //!< sets position to spawn new BasicArrows
    
    /*!
     * Sets spawntime of next basic arrow to Time.time + spawntimer.
     * @post a set object invisible object that spawns more basearrows.
     */
    new void Start() {
        BaseArrow = base.gameObject.GetComponent<Arrow>();
        BaseArrow.Start();
        spawntime = Time.time + spawntimer;
		base.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        InitialPosition = transform.position;
        //Debug.Log("Fast Arrow");
    }
    /*!
     * Calls baseArrow fixedUpdate() and then instantiates more arrows if Time.time > spawntime
     */
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
