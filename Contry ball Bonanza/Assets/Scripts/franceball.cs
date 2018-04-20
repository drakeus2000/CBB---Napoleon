using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class franceball : MonoBehaviour {
	
	public float maxStreach = 3f;
	private SpringJoint2D spring;
	private Transform catapult;
	public bool clickedon = false;
	private float maxStrechSqr;
	private Ray rayToMouse;
	private Vector2 prevVelocity;
	public AudioClip myclip;
    public float trenutna_masa = 2f;




    ///	public GameObject catapult;

    // Use this for initialization
    void Awake () {
		spring = GetComponent <SpringJoint2D> ();
		catapult = spring.connectedBody.transform;
	}
	void Start () {

        GetComponent<CircleCollider2D>().radius = 4f;
		rayToMouse = new Ray(catapult.position, Vector3.zero);
		maxStrechSqr = maxStreach * maxStreach;
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
		GameObject.Find ("Main Camera").GetComponent <CameraMove> ().player_go = this.gameObject;
		GameObject.Find ("Main Camera").GetComponent <CameraMove> ().Start();
		Debug.Log ("uspesno poslao");

    }
	
	void Update () {
		if (clickedon)
			Dragging ();
		
		if (spring != null) {
			if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude) {
				Destroy(spring);
				this.GetComponent<AudioSource>().Play();
				GetComponent<Rigidbody2D>().velocity = prevVelocity;
			}
			if (!clickedon)
				prevVelocity = GetComponent<Rigidbody2D>().velocity;
		} 
	}
	void OnMouseDown () {
		spring.enabled = false;
		clickedon = true;
		GameObject.Find ("Main Camera").GetComponent <CameraMove> ().update_franceball ();
		GetComponent<Collider2D>().enabled = false;
	}
	void OnMouseUp () {
		spring.enabled = true;
		GetComponent<Collider2D>().enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().mass = trenutna_masa;
        GetComponent<CircleCollider2D>().radius = 1.5f;
		clickedon = false;
		GameObject.Find ("Main Camera").GetComponent <CameraMove> ().update_franceball ();
		GameObject.Find ("Main Camera").GetComponent <CameraMove> ().fired_franceball();
	}
	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
		mouseWorldPoint.z = 0f;
		
		if (catapultToMouse.sqrMagnitude > maxStrechSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStreach);
		}
		
		transform.position = mouseWorldPoint;

        

    }	
}
