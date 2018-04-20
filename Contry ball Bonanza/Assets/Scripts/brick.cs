using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class brick : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	public Sprite brick_hurt_a_little;
	public Sprite brick_hurt_a_lot;
	public float hitpoint = 0;
	public GameObject UIDamageObstacle;
	public float maxhitpoint;
	Vector3 tempcolider;
	GameObject allthefunctions;
	public AudioClip myclip;
    private Color[] textColor = { Color.blue, Color.cyan, Color.gray, Color.green, Color.grey, Color.magenta, Color.red, Color.white, Color.yellow };
    private int index;
    // Use this for initialization
    void Start () {
		spriteRenderer = GetComponent <SpriteRenderer> ();
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
		if (hitpoint == 0)
			hitpoint = maxhitpoint;
		else if (hitpoint < maxhitpoint/1.5f) 
			spriteRenderer.sprite = brick_hurt_a_lot;
		else if (hitpoint < maxhitpoint/3f)
			spriteRenderer.sprite = brick_hurt_a_little;
		allthefunctions = GameObject.FindGameObjectWithTag ("allthefunctions");
        index = Random.Range(0, textColor.Length);
    }
	
	// Update is called once per frame

	void OnCollisionEnter2D (Collision2D collision) {

		float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 11;
		tempcolider = new Vector3(collision.gameObject.transform.position.x,collision.gameObject.transform.position.y,collision.gameObject.transform.position.z);
		if (collision.gameObject.name == "playerball") {
			damage = damage * 3;
			if (damage > 90)
			this.GetComponent<AudioSource>().Play();
		}
		if (collision.gameObject.tag == "Border") {
			hitpoint = hitpoint - damage * 2000;
		}
		int damageint = (int)damage;
		hitpoint = hitpoint - damageint;
		if (damage > 100) {
			intUIDamageObstacle (damageint.ToString ());
		}
		allthefunctions.GetComponent<GameControler>().myscore +=  damageint;
		if (hitpoint <= 1)
			Kill ();
		else if (hitpoint < maxhitpoint/3f) 
			spriteRenderer.sprite = brick_hurt_a_lot;
		else if (hitpoint < maxhitpoint/1.5f)
			spriteRenderer.sprite = brick_hurt_a_little;
	}
	void Kill () {
			//	As the particle system is attached to this GameObject, when Killed, switch off all of the visible behaviours...
			spriteRenderer.enabled = false;
			GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().drag = 20.0f;
        //GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent<ParticleSystem>().Play();
		}

	void intUIDamageObstacle (string text) {
		GameObject temp = Instantiate (UIDamageObstacle) as GameObject;
		RectTransform tempRect = temp.GetComponent <RectTransform>();
	//	temp.transform.SetParent(transform.FindChild("BrickCanvas"));
		temp.transform.localPosition = tempcolider;
		temp.transform.localScale = UIDamageObstacle.transform.localScale;
		temp.transform.localRotation = UIDamageObstacle.transform.localRotation;
        temp.GetComponent<MeshRenderer>().material.SetColor("_Color", textColor[index]);
        temp.GetComponent<TextMesh>().text = text;
		Destroy (temp.gameObject, 2);
		}
}