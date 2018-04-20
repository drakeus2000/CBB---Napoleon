using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class GameControler : MonoBehaviour
{

    public int Broj_nivoa;
    public int brojprotivnika_counter;
    public GameObject novalopta;
    public AudioClip ale;
    GameObject Gameoverobject;
    GameObject HudDisplay;
    Vector3 lokacija_fra_kuglice;
    GameObject levelpass;
    public int myscore;
    int otkljucanlvl;
    int temp_killedballs = 0;
    //ovo je prebaceno iz pauze
    GameObject[] pauseObjects;
    bool pauza = true;
    public bool adwattched = false;
    public GameObject UIDamageObstacle;
    public Vector3 infoText_lokacija;
    ushort koliko_sema_po_reklami = 15;
    public ushort brojac;
    public int varanje = 8; // obrisi sve vezano za mene

    // Use this for initialization
    void Awake()
    {
        brojac = GameObject.FindGameObjectWithTag("reklame").GetComponent<reklame>().brojac;
        playadcheck();
        brojac++;
        GameObject.FindGameObjectWithTag("reklame").GetComponent<reklame>().brojac = brojac;
        PlayerPrefs.SetInt("otkljucanlvl", Broj_nivoa);
        Gameoverobject = GameObject.FindGameObjectWithTag("ShowOnGameOver");
        brojprotivnika_counter = GameObject.FindGameObjectsWithTag("protivnici").Length;
        HudDisplay = GameObject.FindGameObjectWithTag("HudDisplay");
        levelpass = GameObject.FindGameObjectWithTag("levelpass");
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
    }
    void Start()
    {
        otkljucanlvl = PlayerPrefs.GetInt("otkljucanlvl", Broj_nivoa);

        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = ale;
        /*	foreach (GameObject g in Gameoverobject) {
                Debug.Log ("test uspesan za sakrivanje gameovera");*/
        Gameoverobject.SetActive(false);
        levelpass.SetActive(false);
        hidePaused();

        lokacija_fra_kuglice = GameObject.FindGameObjectWithTag("PlayerBall").transform.position;
    }
    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
    public void playadcheck()
    {
        if (brojac % koliko_sema_po_reklami == 0)
        {
            ShowAd();
        }
    }
    public void ShowAd()
    {
        Advertisement.Show();
    }
    public void RestartButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void napisitextmultiball()
    {
        temp_killedballs++;
        
        if (temp_killedballs >= 2)
        {
            if (temp_killedballs == 2)
            {
                intUIDamageObstacle("Double Ball Bonanza!!!");
            }
            else intUIDamageObstacle("Multi Ball Bonanza!!!");
        }
    }
    public void Killball()
    {
        napisitextmultiball();
        brojprotivnika_counter -= 1;
        if (brojprotivnika_counter == 0)
        {
            HudDisplay.SetActive(false);
            StartCoroutine(sacekajtri());

            //		Destroy (GameObject.FindGameObjectWithTag ("PlayerBall"));

        }
    }
    IEnumerator sacekajtri()
    {
        yield return new WaitForSeconds(3.0f);
        GameObject.FindGameObjectWithTag("Damager").GetComponent<ParticleSystem>().Play();
        GameObject.FindGameObjectWithTag("Damager").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Damager").GetComponent<Collider2D>().enabled = false;
        GameObject.FindGameObjectWithTag("Damager").GetComponent<Rigidbody2D>().isKinematic = true;
        //		Destroy (GameObject.FindGameObjectWithTag ("PlayerBall"));
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 0;
        showvictorymenu();
    }
    void showvictorymenu()
    {
        if (otkljucanlvl <= Broj_nivoa)
        {
            otkljucanlvl = Broj_nivoa + 1;
            PlayerPrefs.SetInt("otkljucanlvl", otkljucanlvl);
        }


        levelpass.SetActive(true);
        levelpass.GetComponentInChildren<remaininglives>().budan();
    }
    public void NewBall()
    {
        temp_killedballs = 0;
        this.GetComponent<AudioSource>().Play();
        Destroy(GameObject.FindGameObjectWithTag("PlayerBall"));
        Quaternion Kvaternion = new Quaternion(0, 0, 0, 0);
        Instantiate(novalopta, lokacija_fra_kuglice, Kvaternion);
        //num_of_lives--;
        varanje--;

        //       GameObject.FindGameObjectWithTag("ScoreDisplayonGui").GetComponent<displaylives>().num_of_lives = num_of_lives;
        GameObject.FindGameObjectWithTag("ScoreDisplayonGui").GetComponent<displaylives>().num_of_lives = varanje;

        /*        if (num_of_lives < 0)
                {
                    num_of_lives = 0;
                    Time.timeScale = 0;

                    Gameoverobject.SetActive(true);

                    HudDisplay.SetActive(false);
                } */
        if (varanje < 0)
        {
            varanje = 0;
            Time.timeScale = 0;

            Gameoverobject.SetActive(true);

            HudDisplay.SetActive(false);
        }



        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().restore_camera();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().firedball = false;
    }
    public void TogglePause()
    {
        if ((Time.timeScale == 1) && (pauza))
        {
            pauza = !pauza;
            Time.timeScale = 0;
            showPaused();
        }
        else if ((Time.timeScale == 0) && (!pauza))
        {
            pauza = !pauza;
            Debug.Log("high");
            Time.timeScale = 1;
            hidePaused();
        }
    }
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    public void LoadMainMenu()
    {
        Application.LoadLevel("mainmenu");
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Broj_nivoa+1);
    }
    public void Get_two_moreballs()
    {
        varanje = 3;
        Gameoverobject.SetActive(false);
        HudDisplay.SetActive(true);
        Time.timeScale = 1;
        NewBall();
    }
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                adwattched = true;
                Get_two_moreballs();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
    void intUIDamageObstacle(string text)
    {
        GameObject temp = Instantiate(UIDamageObstacle) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        //	temp.transform.SetParent(transform.FindChild("BrickCanvas"));
        temp.transform.localScale = UIDamageObstacle.transform.localScale;
        temp.transform.localRotation = UIDamageObstacle.transform.localRotation;
        infoText_lokacija.y = infoText_lokacija.y + Random.Range(2, 4);
        infoText_lokacija.y = infoText_lokacija.x + Random.Range(2, 4);
        temp.transform.localPosition = infoText_lokacija;
        temp.GetComponent<TextMesh>().text = text;
        Destroy(temp.gameObject, 2);
    }
}