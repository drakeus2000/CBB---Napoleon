using UnityEngine;
using System.Collections;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class googleplay : MonoBehaviour {

	void Awake() {
//		PlayGamesPlatform.Activate ();
	}
	// Use this for initialization
	void Start () {
		Social.localUser.Authenticate ((bool success) => {});
	}
}
