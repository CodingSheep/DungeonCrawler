using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /*! \class Player
     * Everything player related is in this class
     */

	
	public int maxHealth = 5; //!< Maxhealth of the player
 	public int health = 5; //!< Current health that gets changed
	public float speed = 5.0f; //!< Starting speed of the player
    public float rotationSpeed; //!< rotational speed of the player
	public float arrowSpeed = 40f; //!< How fast arrows are initially shot at
	public float arrowDmg = 5f; //!< How much damage arrows initially do
	public int burnAmount = 5; //!< Default "burn" damage for fire arrows
	public float freezeTime = 2f; //!< default "Freeze" time for ice arrows
	public float slowMult = 1.5f; //!< Default speed multiplier for slow arrows

	private bool invulnerable = false; //!< Sets invulnerablility after player has taken damage
     
	private Camera mainCam; //!< main camera object
	private Ray camRay; //!< Ray from camera to mouse position
	private RaycastHit camRayHit; //!< Hit point of raycast
	private Vector3 deltamovement; //!< Change in movement 
    private GameController gamecontroller; //!< Gamecontroller object
    private SpellController spellUI; //!< SpellController object
	private UIController uic; //!< UI Controller object

    private double timeHeld; //!< Time holding fire
	private double test;
	private bool rightClicked; //!< Bool for clicking the right mouse button
	private float speedAfterPause; //!< Pausing handling 

	//Health 2.0
	public Texture2D HpBarTexture; //!< Texture for player healthbar
	public Texture2D HpBackTexture; //!< back texture for Player health
	float hpBarLength; //!< Length of healthbar

    private Animator anim; //!< Animator controller 

    /*!
     * Instantiates member values
     */
    void Start()
    {
        anim = GetComponent<Animator>();
        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //cursor = GameObject.FindGameObjectWithTag("Cursor");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        spellUI = GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>();
		uic = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();

        timeHeld = 0.0;
    }

    /*!
     * Updates member valeus
     * Health set to appropriate length
     * Also handles basic inputs for walking animation
     */
    void Update()
	{
		//Update player health
		hpBarLength = ((float)health / maxHealth) * 100;

		//Movement when paused or unpaused
		if (!gamecontroller.isPaused)
			Movement ();

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
			anim.SetBool("Walking", true);
        }else {
			anim.SetBool("Walking", false);
        }
    }

    /*!
     * Aim the player Polar the mouse's current position on screen to the game world
     */
    void FixedUpdate() {
		if (!gamecontroller.playerIsFiring && !gamecontroller.isPaused) {
            AimPlayer();
        }
    }
    /*!
     * Handels collision events
     */
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy" && !invulnerable) {
			if (health > 1) {
				health--;
				invulnerable = true;
				Invoke ("ResetVulnerability", 2f);
			} else {
				if (uic.GetScore () > PlayerPrefs.GetInt ("highscore")) {
					PlayerPrefs.SetInt ("highscore", uic.GetScore ());
				}
				uic.ShowGameOver ();
			}
		}
	}

    /*! 
     * Handles how collisions interact when remaining inside the hitboxes of the player
     */
    void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Enemy" && !invulnerable) {
			if (health > 1) {
				health--;
				invulnerable = true;
				Invoke ("ResetVulnerability", 2f);
			} else {
				if (uic.GetScore () > PlayerPrefs.GetInt ("highscore")) {
					PlayerPrefs.SetInt ("highscore", uic.GetScore ());
				}
				uic.ShowGameOver ();
			}
		}
	}

    /*!
     * Aims player at the position the Mouse casts onto the gameworld
     */
    void AimPlayer() {
		camRay = mainCam.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast(camRay, out camRayHit)) {
			Vector3 targetPos = new Vector3(camRayHit.point.x, transform.position.y, camRayHit.point.z);

            transform.LookAt(targetPos);
			transform.eulerAngles = transform.eulerAngles + 180 * Vector3.up;
		}
	}

    /*! 
     * Handles movement of the player in the gameworld with key interactiosn and Unitys SimpleMovement class
     */
	void Movement () {
		//Uses the default Unity Input object too manage player input. This allows for multiple platforms, and easy customization in the future.
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		deltamovement = transform.position + speed * (new Vector3(h, 0, v)).normalized * Time.deltaTime; //Vector of movement direction * time since last called.
		//Im very sure this bit is obvious, though I will explain the Time.deltaTime.
		//Time.deltaTime is basically the time it took to finish the last frame
		//It's used with speed to basically say "I want to move 5 meters per second, not 5 meters per frame"
		GetComponent<CharacterController>().SimpleMove(speed * new Vector3(h, 0, v).normalized);

		//transform.position = deltamovement;
	}

	//!< Test for Health Bar
	void OnGUI() {
		if (!uic.isGameOver) {
			GUI.DrawTexture (new Rect ((Screen.width / 2) - 50, (Screen.height / 2) - 50, 100, 10), HpBackTexture);
			GUI.DrawTexture (new Rect ((Screen.width / 2) - 50, (Screen.height / 2) - 50, hpBarLength, 10), HpBarTexture);
		}
	}
    //!< Undoes the invulnerablitiy of the player
	void ResetVulnerability() {
		invulnerable = false;
	}
}
