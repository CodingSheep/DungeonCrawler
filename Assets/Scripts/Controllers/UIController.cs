using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    /*! \class UIController
     * Controller object that handles most UI interactions in the GameScene
     */
    private GameObject player; //!< Player object

    public Texture2D cursorTexture; //!< Custom Cursor textures changed in the Editor
    private Vector2 hotSpot = Vector2.zero; //!< Offset of the cursor (based on where anchor is set)

    public GameObject AimLine; //!< Gameobject that handles aim line
    public GameObject ShootingAimLine; //!< Gameobject that handles the growing line
    private GameObject shootline; //!< private gameobject
    public bool isShooting; //!< Boolean object used in shootingaimline

	public List<GameObject> circleTypes; //!< List of OsuCircles that spawn around the player when firing

	private Text scoreText; //!< Score
	private int score; //!< current Int value of score

	public bool isGameOver = false; //!< Managed in scenes and menus (death menu)
	public Canvas gameOver; //!< Death menu canvas
	public Text gameOverScore; //!< Death menu Text object 
	public Text gameOverHighScore; //!< Death menu Highscore text

	public bool isPause = false; //!< boolean handles pausing and pause canvas

    public GameObject OsuCircle; //!< Instantiate blank OsuCircle gameobject

    /*!
     * Instantiates all members and UI Assets
     * Also sets default values for scoores and Canvases
     */
    void Start () {
		Time.timeScale = 1;

        player = GameObject.FindGameObjectWithTag("Player");
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        isShooting = false;
        //ShootingAimLine.transform = player.transform;

		scoreText = GameObject.FindWithTag ("ScoreText").GetComponent<Text> ();

		gameOver = GameObject.Find ("GameOver").GetComponent<Canvas> ();
		gameOverScore = GameObject.Find ("GameOverScore").GetComponent<Text> ();
		gameOverHighScore = GameObject.Find ("GameOverHighScore").GetComponent<Text> ();
    }
    /*!
     * Updates score shown on canvas
     * @param num is the score that needs to be updated
     */
	public void UpdateScore(int num) {
		score += num;
		scoreText.text = "SCORE : " + score;
	}

    /*!
     * Returns score
     */
	public int GetScore() {
		return score;
	}

    /*!
     * Creates the GameOver menu
     */
	public void ShowGameOver() {
		Time.timeScale = 0;
		isGameOver = true;
		scoreText.enabled = false;
		gameOverHighScore.text = "High Score: " + PlayerPrefs.GetInt ("highscore");
		gameOverScore.text = "Score: " + score;
		gameOver.enabled = true;
	}

    /*!
     * Instantiates Shooting UI elements (Like Osu Circles)
     */
    public void Shooting() {
        isShooting = true;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height/2, 0.0f);
        //Debug.Log(center);
        //Debug.Log(Input.mousePosition + " mouse");
        Vector3 Radial = center + (Input.mousePosition - center).normalized * 200;

		for (int i = 0; i < circleTypes.Count; i++) {
			Vector3 offset = new Vector3 (Mathf.Cos(2 * Mathf.PI * ((float)i/circleTypes.Count)), Mathf.Sin(2 * Mathf.PI * ((float)i/circleTypes.Count)), 0);
			GameObject toSpawn = Instantiate(circleTypes[i], center + (offset * 200), Quaternion.identity, this.transform ) as GameObject;
            //! reads in list of CircleTypes (prefabs)
		}

    }
    /*!
     * UI Elements on shooting Release
     */
    public void Release() {
        isShooting = false;
        GameObject[] Circles = GameObject.FindGameObjectsWithTag("OsuCircle");

        for (var i = 0; i < Circles.Length; i++) {
            Destroy(Circles[i]);
        }
    }
}
