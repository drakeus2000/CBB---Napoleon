using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dugmelevela : MonoBehaviour {

	private Image spriteRenderer;
//	public Image zakljucanlvl;
	public int ovajlevel;
	static int highbrojlevela;
	int kampanja_koef;
    int provera;

    // Use this for initialization
    void Awake(){


	}
    public void OnEnable()
    {
        //		spriteRenderer = GetComponent <Image> ();
        highbrojlevela = GameObject.Find("Button_functions").GetComponent<play>().otkljucanlvl;
        kampanja_koef = GameObject.Find("Button_functions").GetComponent<play>().koef_kampanje;


        provera = kampanja_koef + ovajlevel;
        Debug.Log("Ovaj level vs max level     " + ovajlevel + "  " + highbrojlevela);
        if (provera <= highbrojlevela)
        {
            //			this.GetComponent<Image>.overrideSprite =  Resources.Load<Sprite>(spriteRenderer);
            this.GetComponent<Button>().interactable = true;
            this.GetComponentInChildren<Text>().enabled = true;
        }
        else
        {
            this.GetComponentInChildren<Text>().enabled = false;
            this.GetComponent<Button>().interactable = false;
        }
    }
	
	// Update is called once per frame
}
