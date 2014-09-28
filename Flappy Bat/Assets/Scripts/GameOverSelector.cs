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

public class GameOverSelector : MonoBehaviour {
	
	public bool isMenu = false;
	public bool isReplay = false;
	
	private Color32 colorbase;
	
	void Start () {
		colorbase.r = 97;
		colorbase.g = 105;
		colorbase.b = 176;
		colorbase.a = 255;
	}
	
	void OnMouseEnter () {
		//change text color
		guiText.color = Color.red;
	}
	
	void OnMouseExit () {
		//change text color
		guiText.color = colorbase;
	}
	
	void OnMouseUp () {
		
		if (isMenu == true) {
			// load main menu
			Application.LoadLevel("Main Menu");
		}
		else if (isReplay == true) {
			// load level 1
			Application.LoadLevel("Level 1");
		}
	}
}
