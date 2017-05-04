using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {
    /*! \class SpellController
     * Handles spell interactions in the game
     */

    private UIController UIController; //!< UIController object for communication
    private GameController GameController; //!< GameController object for communication
    private GameObject player; //!< Player object
	public GameObject basicArrow; //! Basic arrow to be instantiated on load
    public GameObject FastArrow; //!< fastarrow to be instantiated on osucircle click

	public bool firing; //!< boolean to keep track of player state

	private float osuTime; //!< variable to keep track of how close the user was to clicking the circle in time
    public float osuTimeScale; //!< speed of the OsuCircles

    public GameObject loaded; //!< default arrow that gets interchanged on osucircle selection

    /*!
     * Sets member values
     */
	public void Start() {
        UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        player = GameObject.FindWithTag ("Player");
        firing = false;

    }

    /*!
     * Update checks gamestates in current frame for any updates to spell related events, such as new arrows or firing/
     */
	public void Update() {
        UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        if (GameController != null) {
            if (GameController.playerIsFiring) {
                osuTime += osuTimeScale * Time.deltaTime;
            }
        }
    }

    /*!
     * @param instantiates an arrow gameobject
     */
	public void SpawnArrow(GameObject arrow) {
		GameObject toSpawn = Instantiate (arrow, player.transform.position, player.transform.rotation, this.transform);
	}
    /*!
     * Starts the arrow shooting sequence. Sets loaded arrow to default basicArrow.
     * Loaded then changes based on whether or not an Osucircle had been clicked.
     */
    public void StartSpawnSequence()
    {
		UIController.Shooting();
        loaded = basicArrow;
        osuTime = 0;
    }

    /*!
     * Instantiates the loaded arrow upon bow release
     */
    public void EndSpawnSequence()
    {
		UIController.Release();
        SpawnArrow(loaded);
        osuTime = 0;
    }
    /*!
     * returns a float (seconds) on how close the player was to hitting the Approach circle in the appropriate time
     */
    public float GetOsuTime() {
        return osuTime;
    }
}
