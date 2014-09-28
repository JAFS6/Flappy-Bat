/*
Copyright 2014 Juan Antonio Fajardo Serrano

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	static public bool started;
	GameObject starthint;
	GameObject score_txt;
	int score;
	GameObject bat;
	Animator bat_animator;
	
	void Start () {
		starthint = GameObject.Find("StartHint");
		Vector3 hintpos = new Vector3();
		hintpos = starthint.transform.position;
		hintpos.y = 0.7f;
		starthint.transform.position = hintpos;

		score_txt = GameObject.Find ("ScoreNumber");
		score_txt.guiText.text = "0";
		score = 0;

		bat = GameObject.Find ("Bat");
		bat_animator = bat.GetComponent<Animator> ();

		started = false;
	}
	
	void Update () {

		if( started ) {

		}
		else if( !started && Input.GetKeyDown(KeyCode.Space) ) {
			// Hide start hint
			Vector3 hintpos = new Vector3();
			hintpos = starthint.transform.position;
			hintpos.y += 3;
			starthint.transform.position = hintpos;
			// Set started game to true
			started = true;
			// Make bat be affected by gravity
			bat.rigidbody2D.gravityScale = 0.4f;
			// Tell the bat animator, the game has started
			bat_animator.SetBool("Started",true);
		}
	}
}
