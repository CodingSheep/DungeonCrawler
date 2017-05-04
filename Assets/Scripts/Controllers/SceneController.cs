﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void LoadGame() {
		SceneManager.LoadScene ("testworld");
	}
	public void LoadMenu() {
		SceneManager.LoadScene ("menu");
	}
	public void Quit() {
		Application.Quit ();
	}
}