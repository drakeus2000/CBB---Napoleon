using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class getextraballs : MonoBehaviour
{
    bool adwatched;
    // Use this for initialization
    void Awake()
    {


    }
    public void OnEnable()
    {
        //		spriteRenderer = GetComponent <Image> ();
        adwatched = GameObject.Find("Allthefunctions").GetComponent<GameControler>().adwattched;
        if (adwatched)
        {
            //			this.GetComponent<Image>.overrideSprite =  Resources.Load<Sprite>(spriteRenderer);
            this.GetComponent<Button>().interactable = false;
        }

        // Update is called once per frame
    }
}
