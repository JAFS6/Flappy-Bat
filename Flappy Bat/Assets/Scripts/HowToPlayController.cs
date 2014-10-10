using UnityEngine;
using System.Collections;

public class HowToPlayController : MonoBehaviour {

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// load main menu
			Application.LoadLevel("Main Menu");
		}
	}
}
