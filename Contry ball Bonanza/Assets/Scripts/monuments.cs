using UnityEngine;
using System.Collections;

public class monuments : MonoBehaviour {
	private int currentHitPoints;
	public int hitpoint;

	GameObject allthefunctions;
	public int scoreValue;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		//	Initialize the Hit Points
		currentHitPoints = hitpoint;
		spriteRenderer = GetComponent <SpriteRenderer> ();
		allthefunctions = GameObject.FindGameObjectWithTag ("allthefunctions");
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		//	Check the colliding object's tag, and if it is not "Damager", exit this function
//		if (collision.collider.tag != "Damager")
//			return;
		float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
		if (collision.gameObject.name == "playerball") {
			damage = damage * 5;
		}
		int damageint = (int)damage;
		allthefunctions.GetComponent<GameControler>().myscore +=  damageint;
		currentHitPoints = currentHitPoints - damageint;
		if (currentHitPoints <= 1)
			Kill ();
		}
	
	void Kill () {
		//	As the particle system is attached to this GameObject, when Killed, switch off all of the visible behaviours...
		spriteRenderer.enabled = false;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().isKinematic = true;
		allthefunctions.GetComponent<GameControler>().myscore +=  scoreValue;
		//	... and Play the particle system
		GetComponent<ParticleSystem>().Play();
	}
}
