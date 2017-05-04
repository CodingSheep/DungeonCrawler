using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    /*! \class PauseMenu
     * Handles the pause button and toggles the GameController
     */ 
	public GameController GC; //!< GameController object

	/*!
     * if espace is pressed, the gamecontroller will pause the game with "TogglePauseMenu"
     */
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			GC.TogglePauseMenu ();
	}
}
