using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;


public class play : MonoBehaviour {
	public AudioClip myclip;
	public GameObject list_of_levels;
	public GameObject lista_kampanja;
	public GameObject mainscreen;
    public GameObject QuitMenu;
    public GameObject SupportUsMenu;
    public GameObject Appology;
    public int otkljucanlvl;
	public int koef_kampanje = 0;


	void Awake () {

		otkljucanlvl = PlayerPrefs.GetInt ("otkljucanlvl", 2);
	//	Debug.Log (otkljucanlvl+ "ja sam iz play");

	}
	void Start () {
		Time.timeScale = 1;

//		list_of_levels = GameObject.FindGameObjectsWithTag("listoflevels");
 //   	lista_kampanja = GameObject.Find("Lista kampanja");
//		mainscreen = GameObject.FindGameObjectsWithTag("mainscreen");
		hidelistoflevels ();
		hidelistofcampains ();

		}

	public void hidemainmenu (){
		this.gameObject.AddComponent<AudioSource> ();
		this.GetComponent<AudioSource> ().clip = myclip;
		this.GetComponent<AudioSource> ().Play ();
//		foreach (GameObject g in mainscreen) {
            mainscreen.SetActive (false);
//		}
	}

	public void showlistofcampains(){
        koef_kampanje = 0;
        hidemainmenu ();
        hidelistoflevels ();
  //      foreach (GameObject g in lista_kampanja){
            lista_kampanja.SetActive(true);
	//	}
	}
	public void showlistoflevels(int kampanje){
		koef_kampanje = kampanje;
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
		this.GetComponent<AudioSource>().Play();
		hidelistofcampains ();
        //		foreach(GameObject g in list_of_levels){
        list_of_levels.SetActive(true);
//		}
	}
	public void showmainscreen(){
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
		this.GetComponent<AudioSource>().Play();
		hidelistofcampains ();
        QuitMenu.SetActive(false);
        SupportUsMenu.SetActive(false);
        Appology.SetActive(false);

        //		foreach(GameObject g in mainscreen){
        mainscreen.SetActive(true);
//		}
	}
	void hidelistofcampains (){
//        foreach (GameObject g in lista_kampanja) {
            lista_kampanja.SetActive (false);
//		}
	}
	public void hidelistoflevels(){
//		foreach (GameObject g in list_of_levels) {
            list_of_levels.SetActive (false);
//		}
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
            AreYouSureYouWantToQuit();
	}
	
	public void Pocni_igru(int nivo){

        // this object was clicked - do something

        this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
		this.GetComponent<AudioSource>().Play();
		Application.LoadLevel(nivo + koef_kampanje);
	}
	public void Deletaplayerstats(){
		PlayerPrefs.DeleteAll ();
        Application.LoadLevel("mainmenu");
    }
    public void AreYouSureYouWantToQuit()
    {
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = myclip;
        this.GetComponent<AudioSource>().Play();
        hidemainmenu();
        QuitMenu.SetActive(true);
    }
	public void Zavrsi_igru(){
		// this object was clicked - do something
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
		this.GetComponent<AudioSource>().Play();
		Application.Quit();
	}
    public void SupportUs()
    {
        ShowRewardedAd();

    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    public void Supportusmenu()
    {
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = myclip;
        this.GetComponent<AudioSource>().Play();
        hidemainmenu();
        SupportUsMenu.SetActive(true);
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                showmainscreen();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
    public void AppologyMenu()
    {
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = myclip;
        this.GetComponent<AudioSource>().Play();
        hidemainmenu();
        Appology.SetActive(true);
    }
}
