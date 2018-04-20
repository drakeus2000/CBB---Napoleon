using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class remaininglives : MonoBehaviour {
	int num_of_lives;
	public int vrednost_zivota;
	public int vrednost_3_zvezdice;
	public int vrednost_2_zvezdice;
	int konacan_skor_zivoti;
	Text jetext_zivoti;
	int score;
	int konacan_skor;
	int Broj_nivoa;
	int highscore_ovajlvl;
	// Use this for initialization
	public void budan (){
		jetext_zivoti = GetComponent <Text> ();
		score = GameObject.FindGameObjectWithTag ("allthefunctions").GetComponent <GameControler> ().myscore;
		Broj_nivoa = GameObject.FindGameObjectWithTag ("allthefunctions").GetComponent <GameControler> ().Broj_nivoa;
		highscore_ovajlvl = PlayerPrefs.GetInt ("h" + Broj_nivoa, 0);

		pocni ();
	}
	void pocni () {
		num_of_lives = GameObject.FindGameObjectWithTag ("allthefunctions").GetComponent <GameControler> ().varanje;
		konacan_skor_zivoti = vrednost_zivota * num_of_lives;
		konacan_skor = konacan_skor_zivoti + score;
		//prikazuje sliku na zavrsetku seme
		if (konacan_skor > vrednost_3_zvezdice)
			this.GetComponentInChildren<koliko_sablji_game_meni>().postavi_sablje (3);
		else if (konacan_skor > vrednost_2_zvezdice)
			this.GetComponentInChildren<koliko_sablji_game_meni>().postavi_sablje (2);
		if (highscore_ovajlvl < konacan_skor) {
			PlayerPrefs.SetInt ("h" + Broj_nivoa,konacan_skor);
			jetext_zivoti.text = "Score: " + score + " \n" + "Lives: " + konacan_skor_zivoti + "\n" + "New Highscore Total: " + konacan_skor;
			if (konacan_skor>vrednost_3_zvezdice)
				PlayerPrefs.SetInt ("s" + Broj_nivoa,3);
			else if (konacan_skor>vrednost_2_zvezdice)
				PlayerPrefs.SetInt ("s" + Broj_nivoa,2);
			else
				PlayerPrefs.SetInt ("s" + Broj_nivoa,1);
			}
		else {
			jetext_zivoti.text = "Score: " + score + " \n" + "Lives: " + konacan_skor_zivoti + "\n" + "Total: " + konacan_skor + "\n" + "Old Highscore: " + highscore_ovajlvl;
		}
		//ovde postavi funkciju koja poziva one loptice
	}
	// Update is called once per frame

}
