using UnityEngine;
using System.Collections;

public class bumper : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	public Sprite swissgiggling;
	public Sprite original;
	public AudioClip myclip;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent <SpriteRenderer> ();
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnCollisionEnter2D (Collision2D collision) {
		this.GetComponent<AudioSource>().Play();
		spriteRenderer.sprite = swissgiggling;
		StartCoroutine(ChangeFace ());
	}
	public IEnumerator ChangeFace ()
	{
		yield return new WaitForSeconds (1.0f);
		spriteRenderer.sprite = original;
	}


}
