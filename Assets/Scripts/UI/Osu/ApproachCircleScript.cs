using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachCircleScript : MonoBehaviour {
    /*! \class ApproachCircleScript
     *  Script for handling how the circle around the osu circles interact
     */
    // Use this for initialization
    public int segments; //!< how many lines the circle is drawn with
    public float xradius; //!< Initial xRadius @note should be the same as Y for a circle
    public float yradius; //!< Initial yRadius @note should be the same as X for a circle
    LineRenderer line; //!< Line rendere of the approach circle

    /*!
     * sets Member values and creates LineRenderes from gameobject
     */
    void Start() {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }

    /*!
     * Handles points created
     */
    void CreatePoints() {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++) {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }
}
