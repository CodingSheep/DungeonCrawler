using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsuCircle : MonoBehaviour {

	// Use this for initialization
	public float collapse_speed;
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
    public GameObject Arrow;

    public float TimeDelay;
    private float PerfectHitTime;

    private float hitScore;

    private RectTransform ApproachCircle;
    private float ApproachRate;

    public float approachDistance;


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
    }

	// Update is called once per frame
	void Update () {
        if (Time.time - PerfectHitTime > 0) {
            if(ApproachCircle != null) {
                Destroy(ApproachCircle.gameObject);
            }
        }else {
            float AP = ApproachRate * Time.deltaTime;
            ApproachCircle.localScale = ApproachCircle.localScale - new Vector3(AP, AP, AP);
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
	public void HitCircle() {
        ExchangeArrow();
        hitScore = Time.time - PerfectHitTime;
        Debug.Log(hitScore);
    }
    public void ExchangeArrow() {
        GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>().loaded = Arrow;
    }
}
