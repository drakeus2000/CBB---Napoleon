using UnityEngine;
using System.Collections;

public class bigcomplexthing : MonoBehaviour {


	public GameObject postobjekat;
    public float borderdamage;
    public AudioClip myclip;
    bool ne_dupliraj = false;
    // Use this for initialization
    void Start () {
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = myclip;
    }
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.name == "playerball")
        {
                this.GetComponent<AudioSource>().Play();
        }
        float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 120;
		if (damage > borderdamage) {
			Destroy(gameObject);
            if (!ne_dupliraj){ 
			Instantiate(postobjekat, transform.position, transform.rotation);
            ne_dupliraj = true;
            }
        }
	}
}
