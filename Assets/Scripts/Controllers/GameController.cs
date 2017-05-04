using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	/*! \class GameController 
     * Manages overall gameflow and inputs not directly linked to player
     */
	public GameObject OsuCircle; //!< OsuCircle gameobject to be instantiated
    public bool playerIsFiring; //!< boolean to handle firing control
	public bool isPaused; //!< boolean to handel pause controll

	private SpellController spellController; //!< SpellController in scene to communicate with
	public PauseMenu Menu; //!< PauseMenu object to handle pausing
	private UIController UI; //!< UIController object to handle other UI related events

    /*!
     * Sets default members and privates.
     */
	void Start () {
        spellController = GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>();
        playerIsFiring = false;
		isPaused = false;
    }

	/*!
     * Checks for any updates that need to be applied to game world
     * such as if a player has held down the shoot button
     */
	void Update () {
        /*!
         * Unused Osucircle testing function
         */
		if (Input.GetKeyDown (KeyCode.Q)) {
			//creates game object
			GameObject osu_Circle= Instantiate (OsuCircle);

			//displaces the circle 2 times its size above player
			float displacement = osu_Circle.transform.localScale.x * 50;

			//sets postions and parent
			osu_Circle.transform.SetParent (GameObject.FindGameObjectWithTag ("UIController").transform);
			osu_Circle.transform.position = new Vector2 (Screen.width / 2, Screen.height / 2 + displacement);
		}

		if (Input.GetButtonDown("Fire2")) //! @note Fire2 is the default mousebutton 2 on PC, but can be used on other platforms when defining global controlls

		{
			//if (finalHit == null)
			spellController.StartSpawnSequence(); 
			playerIsFiring = true;

		}
		if (Input.GetButtonUp("Fire2")) {
			spellController.EndSpawnSequence();
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().PlayerArrowAttack();
			playerIsFiring = false;
		}
    }
    /*! 
     * Handles pausemenu interaction.
     */
	public void TogglePauseMenu()
	{
		// Not Optimal but readable
		if (Menu.GetComponentInChildren<Canvas>().enabled)
		{
			Menu.GetComponentInChildren<Canvas>().enabled = false;
			isPaused = false;
			Time.timeScale = 1.0f;
		}
		else
		{
			Menu.GetComponentInChildren<Canvas>().enabled = true;
			isPaused = true;
			Time.timeScale = 0.0f; //! stops time (however not updates) Becareful how we set object updates!
		}
	}
}
