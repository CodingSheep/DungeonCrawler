using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsuCircle : MonoBehaviour {
    /*! \OsuCircle
     * Handles OsuCircle objects that get instantiated on holding down fire
     */

	// Use this for initialization
	public float collapse_speed; //!< Speed at which the ApproachCircle collapses
	//public float target_size;
	//public Vector3 scale;
    /*
	private bool shrink;
	private Vector3 offset;
	private GameObject cam;
	private GameObject player;
	private Vector3 pos;
	private OsuCircle[] circle_arr;
    */
    public GameObject Arrow; //!< Type of arrow associated with the OsuCircle
	public enum arrowTypes //!< Types of possible arrow types
	{
		basic = 0, fast = 1, delayed = 2, fire = 3, ice = 4, slow = 5
	}
	public arrowTypes arrowType; //!< Arrow type holder

    public float TimeDelay; //!< Time to hit the circle
    private float PerfectHitTime; //!< Time trime value

    private float hitScore; //!< Holds the score that the player hit the circle with

    private RectTransform ApproachCircle; //!< ApproachCricle's Position handled in later functions
    private float ApproachRate; //!< Defined rate of the aproach Cricle

    public float approachDistance; //!< Distance the Approach circle starts at

    public bool hit; //!< Bool handler wheather the button had beeen clicked

    public AudioSource source; //!< Audio Source

    /*!
     * Instantiates Member values
     */
	void Start () {
        //initializes variables
        /*
		shrink = false;
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
		//sets up osu circle position and rotation
		Quaternion rotation = cam.transform.rotation;
		transform.rotation = Quaternion.Inverse (rotation);
		transform.localScale = scale;
		offset = this.GetComponent<Transform> ().position;

		//add z lenght to offset position from camera
		offset.y -= (UnityEngine.Camera.main.transform.position.y - scale.z /2);
		offset.z -= (UnityEngine.Camera.main.transform.position.z);
		offset.x += 5.0f;
		transform.position = offset;
        */
        PerfectHitTime = Time.time + TimeDelay;
        ApproachCircle = this.GetComponentsInChildren<RectTransform>()[1];
        ApproachCircle.localScale = ApproachCircle.localScale * approachDistance;
        ApproachRate = (1-approachDistance) / (Time.time - PerfectHitTime);
        hit = false;
        source = GetComponent<AudioSource>();
    }

	/*!
     * updates OsuCircle gameobject to check if it has been hit, or is pased its expected lifetime
     */
	void Update () {
        if (Time.time - PerfectHitTime > 0) {
            if(ApproachCircle != null) {
                Destroy(ApproachCircle.gameObject);
            }
        }else {
            if (!hit) {
                float AP = ApproachRate * Time.deltaTime;
                ApproachCircle.localScale = ApproachCircle.localScale - new Vector3(AP, AP, AP);
            }
        }
        if(Time.time - PerfectHitTime > .5f) {
            Destroy(this.gameObject);
        }
        //ApproachCircle.localScale = ApproachCircle.localScale + ((1/Time.deltaTime) * ApproachCircle.localScale);
        /*
		if (shrink) {

			//checks for shrink if variable object has been clicked
			Vector3 shrinkVector = new Vector3 (transform.localScale.x * Time.deltaTime * collapse_speed, 0.0f, transform.localScale.z * Time.deltaTime * collapse_speed);
			transform.localScale -= shrinkVector;

			if (transform.localScale.x < target_size) {
				Destroy (this.gameObject);
			}
		}	
        */
        
	}


	//updates position
	void LateUpdate(){
		//transform.position = cam.transform.position + offset;
	}

	//void cluster creates a cluster of circles from a parent circle
	public void cluster(int num_of_obj){
        /*
		circle_arr = new OsuCircle[num_of_obj];
		int randomn_val = Random.Range (1, 3);
		float z_output;

		for (int i = 0; i < num_of_obj; i++) {


			//switch statement to choose mathematical function

			switch (randomn_val) {
				
			case 1: 
				z_output = Mathf.Pow (transform.position.x + i + 1.0f, 2);
				break;

			case 2:
				z_output = Mathf.Sin (transform.position.x + i + 1.0f);
				break;
			
			case 3:
				z_output = Mathf.Log (transform.position.x + i + 1.0f, 3);
				break;
			
			default:
				z_output = transform.localPosition.x + i + 1.0f;
				break;

			}
			//start a new circle
			circle_arr [i] = (OsuCircle)Instantiate (this, new Vector3 (transform.position.x + i + 1.0f , 0.0f , z_output), Quaternion.identity);

		}
        */

	}

    /*!
     * Called when a Circle is hit in time
     * 
     */
	public void HitCircle() {
        hit = true;
        ExchangeArrow();
        hitScore = Time.time - PerfectHitTime;
        source.Play();
        //Debug.Log(hitScore);
        //this.gameObject.SetActive(false);
        //Destroy(this.gameObject);
    }
    /*!
     * Changes the arrow in the SpellController to the new arrow that has just been hit.
     */
    public void ExchangeArrow() {
        GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>().loaded = Arrow;
    }
}
