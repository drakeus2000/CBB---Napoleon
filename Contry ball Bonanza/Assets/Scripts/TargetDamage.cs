using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour {

	public int hitpoint;					//	The amount of damage our target can take
//	public Sprite damagedmoreSprite;//	The reference to our "damaged" sprite
//	public float damageImpactSpeed;				//	The speed threshold of colliding objects before the target takes damage

	private int currentHitPoints;				//	The current amount of health our target has taken
 //   private bool firsthit;  dodaj ako hoces gravitaciju pri prvom udarcu
    //	private float damageImpactSpeedSqr;			//	The square value of Damage Impact Speed, for efficient calculation
    private SpriteRenderer spriteRenderer;		//	The reference to this GameObject's sprite renderer
	
	Animator animator;
	public int scoreValue;
//	GameObject textscore;
	GameObject allthefunctions;
    private Color[] textColor = { Color.blue, Color.cyan, Color.gray, Color.green, Color.grey, Color.magenta, Color.red, Color.white, Color.yellow };
    private int index;

    public GameObject UIDamageObstacle;
	Vector3 tempcolider;
    bool unistena = false;
    void Start () {
     //   firsthit = false;  dodaj ako hoces gravitaciju na loptici
        
        //	Get the SpriteRenderer component for the GameObject's Rigidbody
        animator = transform.GetComponentInChildren<Animator> ();
		//	Initialize the Hit Points
		currentHitPoints = hitpoint;
		spriteRenderer = GetComponent <SpriteRenderer> ();
	
		allthefunctions = GameObject.FindGameObjectWithTag("allthefunctions");

        //	Calculate the Damage Impact Speed Squared from the Damage Impact Speed
        //		damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
        index = Random.Range(0, textColor.Length);
    }
	
	void OnCollisionEnter2D (Collision2D collision) {

  /*     if (!firsthit) {  // dodaj 4 reda ako pri udarcu treba da bude gravitacija na loptici
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
           firsthit = true;
        } */
        //	Check the colliding object's tag, and if it is not "Damager", exit this function
            float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
		if (collision.gameObject.name == "playerball")
			damage = damage * 5;

		int damageint = (int)damage;
		allthefunctions.GetComponent<GameControler>().myscore +=  damageint;
		currentHitPoints = currentHitPoints - damageint;
		if ((currentHitPoints < 1) && (unistena == false)) {
			tempcolider = new Vector3(collision.gameObject.transform.position.x,collision.gameObject.transform.position.y,collision.gameObject.transform.position.z);
			Kill ();
            unistena = true;
        }
		else if (currentHitPoints < hitpoint / 3) {
	//		Debug.Log (currentHitPoints);
			animator.SetInteger ("spainhurt", 2);
		} else if (currentHitPoints < hitpoint / 1.5f) {
			Debug.Log (currentHitPoints + "manja steta");
			animator.SetInteger ("spainhurt", 1);
		}
	}
	
	void Kill () {
		//	As the particle system is attached to this GameObject, when Killed, switch off all of the visible behaviours...
		spriteRenderer.enabled = false;
		GetComponent<Collider2D>().enabled = false;
        //		GetComponent<Rigidbody2D>().isKinematic = true;
        this.gameObject.GetComponent<Rigidbody2D>().drag = 20.0f;
        allthefunctions.GetComponent<GameControler>().myscore +=  scoreValue;
		allthefunctions.GetComponent<GameControler> ().Killball ();
        allthefunctions.GetComponent<GameControler>().infoText_lokacija = tempcolider;
        intUIDamageObstacle (scoreValue.ToString ());
		//	... and Play the particle system
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
