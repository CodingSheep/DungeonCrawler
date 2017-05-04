using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    /*! \class CameraController
     * Class that manages the movement of the Camera
     */

    private Vector3 offset; //!< Offset of the world to camera position

    //Sets up player
    private GameObject player; //!< Player GameObject to track movement

    /*! 
     * @post private members to appropriate objects
     */
    void Start()
    {
        offset = this.GetComponent<Transform>().position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /*!
     * Updates the camera position to follow the player
     * @note LateUpdate() to avoid unexpected behaviors with other gameobject updates(). Last thing in the scene to update
     */
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        //transform.LookAt(player.transform);
    }

}
