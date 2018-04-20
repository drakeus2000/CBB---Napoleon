using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stripslajd : MonoBehaviour
{
    public Sprite[] strip;

    int klik = 0;
    public int maxbrojslajdova;
    public int kojilevelposlestripa;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (klik == maxbrojslajdova)
        {
            Application.LoadLevel(kojilevelposlestripa);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = strip[klik];
            klik++;
        }
    }
    public void preskocistrip()
    {
        Application.LoadLevel(kojilevelposlestripa);
    }
}