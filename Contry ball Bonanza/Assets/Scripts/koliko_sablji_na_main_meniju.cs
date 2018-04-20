using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class koliko_sablji_na_main_meniju : MonoBehaviour {

	public Sprite jedna_sablja;
	public Sprite dve_sablje;
	public Sprite tri_sablje;
	int koliko;
	int broj_levela;
	int kampanja_koef;
    int ovaj_broj;


	// Use this for initialization
	void OnEnable () {
		broj_levela = this.transform.parent.GetComponent<dugmelevela> ().ovajlevel;
		kampanja_koef = GameObject.Find ("Button_functions").GetComponent<play> ().koef_kampanje;
		ovaj_broj = broj_levela + kampanja_koef;
		koliko = PlayerPrefs.GetInt ("s" + ovaj_broj, 0);

		if (koliko == 1)
			GetComponent<Image>().sprite = jedna_sablja;
		else if (koliko == 2)
			GetComponent<Image>().sprite = dve_sablje;
		else if (koliko == 3)
			GetComponent<Image>().sprite = tri_sablje;
	}
}
