using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour {

	public Player player;
	public GameObject UI;

	private Text thing;
	private string text;

	// Use this for initialization
	void Start () {
		thing = UI.GetComponent <Text> ();
		thing.text = "Health: " + player.health + "/" + player.maxHealth;
	}

	// Update is called once per frame
	void Update () {
		thing.text = "Health: " + player.health + "/" + player.maxHealth;
	}
}
