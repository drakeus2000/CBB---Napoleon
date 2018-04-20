using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class koliko_sablji_game_meni : MonoBehaviour {
	
	public Sprite dve_sablje;
	public Sprite tri_sablje;

	// Use this for initialization
	public void postavi_sablje (int koliko) {
		if (koliko == 2)
			GetComponent<Image>().sprite = dve_sablje;
		else if (koliko == 3)
			GetComponent<Image>().sprite = tri_sablje;
		}
	}
	
	// Update is called once per frame
