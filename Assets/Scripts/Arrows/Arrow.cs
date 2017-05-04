using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    /*! \class Arrow
     *  Parent Arrow class, which all arrows extend
     *  @note this class should never be instantiated on its own.
     */
    /*!
     * Overall speed of the arrow (To be extended in child class)
     */
	public float speedMult;
    /*!
     * Overall Lifetime of the arrow in seconds (To be extended in child class)
     */
    public float lifetime = 2f;
	public GameObject model;
    /*!
     * Will be set in Start() function
     */
    public Player player = null;
    public AudioSource source;

	private MobHealth enemy;
    /*!
     * Dictates which kind of arrow 'type' it is. Some arrows are basic even though they aren't just \class BasicArrow s.
     */
	public enum arrowDmgTypes
	{
		basic = 0, fire = 1, ice = 2, slow = 3
	}
	public arrowDmgTypes arrowDmgType = arrowDmgTypes.basic;

    
    /*!
     * any arrow class that extends this, must class this function with BaseArrow = base.gameObject.GetComponent<Arrow>(); BaseArrow.Start();
     */
    public void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Invoke ("DestroySelf", lifetime);
        source = GetComponent<AudioSource>();
        source.Play();
    }
    /*! 
     * Defines movement for all arrows
     * All arrows that extend Arrow bust class this function at somepoint in their fixedUpdate();
     */
    public void FixedUpdate(){
		transform.Translate(Vector3.forward * speedMult * player.arrowSpeed);
    }


    /*! 
     * Event handler for when arrow hits an object with a collider
     * @param col is the other object
     */
    void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Enemy") {
			enemy = col.gameObject.GetComponent<MobHealth> ();

			switch (arrowDmgType) {
			case arrowDmgTypes.basic:
				enemy.DoDamage (player.arrowDmg);
				break;
			case arrowDmgTypes.fire:
				enemy.StartBurn (player.arrowDmg/2f, player.burnAmount);
				break;
			case arrowDmgTypes.ice:
				enemy.ApplyFreeze (player.arrowDmg, player.freezeTime);
				break;
			case arrowDmgTypes.slow:
				enemy.ApplySlow (player.arrowDmg, player.slowMult);
				break;
			}

			DestroySelf();
		} else if (col.gameObject.tag == "World") {
			DestroySelf();
		}
	}

    /*!
     * Function called when Arrow hits something. \
     * @post Destorys Arrow
     */
	void DestroySelf() {
		Destroy(this.gameObject);
	}
}
