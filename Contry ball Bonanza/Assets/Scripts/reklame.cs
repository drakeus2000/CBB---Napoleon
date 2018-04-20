using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reklame : MonoBehaviour {
    public ushort brojac;

	// Use this for initialization
	void Start () {
                DontDestroyOnLoad(this.gameObject);
        }
}
