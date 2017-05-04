using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    /*! \class SpawnController
     * Handles how a specific enemy mob spawns.
     * @note Prefab class
     */

    float playerHealth; //!< Keeps track of current player health
    public GameObject enemy; //!< Type of enemy to spawn
    public float spawnTime; //!< How often that type of enemy spawns
    public Transform[] spawnPoints; //!< avaible spawnpoints for that type of enemy

	/*!
     * Instantiates the SpawnController
     * - Sets spawntime too 3.0f seconds by default
     * - Sets Playerhealth
     * - and starts the spawn sequence
     */
	void Start () {
        spawnTime = 3.0f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health;
        InvokeRepeating("Spawn", 1.0f, spawnTime);
	}

    /*!
     * Spawns a new mob if the player is not dead
     */
    void Spawn()
    {
        if (playerHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
