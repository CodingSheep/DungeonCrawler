using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastArrow : Arrow {
    /*! \class FastArrow
     * A faster moving arrow!
     * Same as basicArrow, except a different prefab with more speed as a default
     * @note Prefab class
     */

    private Arrow BaseArrow; //<! BaseArrow Component 
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
        //Debug.Log("Fast Arrow");
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(base.GetComponent<Arrow>().player);
    }
}
