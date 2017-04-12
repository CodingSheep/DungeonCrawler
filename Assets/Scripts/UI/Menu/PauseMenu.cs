using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameController GC;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			GC.TogglePauseMenu ();
	}
}
