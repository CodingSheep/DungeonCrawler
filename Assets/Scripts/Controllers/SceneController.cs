using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    /*! \class SceneController
     * Handles menu interaction and global interactions
     */

    /*!
     * Loads Testworld scene (with the game)
     */
	public void LoadGame() {
		SceneManager.LoadScene ("testworld");
	}

    /*!
     * Load main menu
     */
	public void LoadMenu() {
		SceneManager.LoadScene ("menu");
	}

    /*!
     * When called, quits the application
     */
	public void Quit() {
		Application.Quit ();
	}
}
