using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OsuCircle : MonoBehaviour {

	// Use this for initialization
	public float collapse_speed;
	//public float target_size;
	//public Vector3 scale;
    ///*
	private bool shrink;
	private Vector3 offset;
	private GameObject cam;
	private GameObject player;
	private Vector3 pos;
	private OsuCircle[] circle_arr;
    //*/
    public GameObject Arrow;

    public float TimeDelay;
    private float PerfectHitTime;

    private float hitScore;

    private RectTransform ApproachCircle;
    private float ApproachRate;

    public float approachDistance;

    public bool hit;

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
    }

	// Update is called once per frame
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

	void OnPointerEnter(PointerEventData eventData) {
		Debug.Log ("dfasd");
		//HitCircle ();
	}

	//updates position
	void LateUpdate(){
		//transform.position = cam.transform.position + offset;
	}

	//void cluster creates a cluster of circles from a parent circle
	public void cluster(int num_of_obj){
        ///*
		circle_arr = new OsuCircle[num_of_obj];
		int random_val = Random.Range (-1, 2);
		float z_output = this.GetComponent<RectTransform> ().localPosition.y + (35 * random_val);
		random_val = Random.Range (-1, 2);
		float x_output = this.GetComponent<RectTransform> ().localPosition.x + (35 * random_val);

		for (int i = 0; i < num_of_obj; i++) {


			//switch statement to choose mathematical function
			/*
			switch (random_val) {
				
			case 1: 
				z_output = Mathf.Pow (this.GetComponent<RectTransform>().localPosition.x + i + 1.0f, 2);
				break;

			case 2:
				z_output = Mathf.Sin (this.GetComponent<RectTransform>().localPosition.x + i + 1.0f);
				break;
			
			case 3:
				z_output = Mathf.Log (this.GetComponent<RectTransform>().localPosition.x + i + 1.0f, 3);
				break;
			
			default:
				z_output = this.GetComponent<RectTransform>().localPosition.x + i + 1.0f;
				break;

			}*/
			//start a new circle
			GameObject newCircle = Instantiate (this.gameObject, Vector3.zero, Quaternion.identity);
			newCircle.transform.SetParent (GameObject.FindWithTag ("UIController").transform);
			newCircle.GetComponent<RectTransform> ().localPosition = new Vector3 (x_output, z_output, 0);//this.GetComponent<RectTransform>().localPosition.x + (i * 400.0f), 0, 0);
			newCircle.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
			newCircle.SetActive (true);
			circle_arr [i] = newCircle.GetComponent<OsuCircle> ();

		}
        //*/

	}
	public void HitCircle() {
        hit = true;
        ExchangeArrow();
        hitScore = Time.time - PerfectHitTime;
        Debug.Log(hitScore);
        this.gameObject.SetActive(false);
		cluster (1);
        Destroy(this.gameObject);
    }
    public void ExchangeArrow() {
        GameObject.FindGameObjectWithTag("SpellController").GetComponent<SpellController>().loaded = Arrow;
    }
}
