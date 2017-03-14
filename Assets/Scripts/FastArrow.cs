using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastArrow : Arrow {
    private Arrow BaseArrow;
    // Use this for initialization
    new

    // Use this for initialization
    void Start()
    {
        BaseArrow = base.gameObject.GetComponent<Arrow>();
        BaseArrow.Start();
        Debug.Log("Fast Arrow");
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(base.GetComponent<Arrow>().player);
    }
}
