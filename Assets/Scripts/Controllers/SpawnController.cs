using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    float playerHealth;
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        spawnTime = 3.0f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health;
        InvokeRepeating("Spawn", 1.0f, spawnTime);
	}

    void Spawn()
    {
        if (playerHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
