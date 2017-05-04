using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArrow : Arrow {
    /*! \class BasicArrow
     * Basic Arrow class
     * This is a default arrow that should be fired when nothing else is loaded/clicked on.
     * @note Prefab class
     */
    
    
    private Arrow BaseArrow; //!< Base arrow component to get set in start()
    // Use this for initialization
    new

    /*!
     * @post calls BaseArrow.Start(), then the parent class handels everything else.
     * @note it appears that this needs to be called otherwise the object won't instantiate it's parent class
     */
    void Start()
    {
        BaseArrow = base.gameObject.GetComponent<Arrow>();
		base.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        BaseArrow.Start();
        //Debug.Log("Basic Arrow");
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(base.GetComponent<Arrow>().player);
    }
}
