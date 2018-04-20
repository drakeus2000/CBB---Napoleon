using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sabljekampanja : MonoBehaviour {
	Text jetext_zivoti;
	int koliko;
	int varx;
	public int donji_broj_levela;
	public int gornji_broj_levela;
	// Use this for initialization
	void Start () {
		jetext_zivoti = GetComponent <Text> ();
		for(int varx = donji_broj_levela; varx < gornji_broj_levela; varx++)
			koliko += PlayerPrefs.GetInt ("s" + varx, 0);

			jetext_zivoti.text = koliko + " / 36";
	}
	
	// Update is called once per fra
}
