﻿/*
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

public class MainMenuController : MonoBehaviour {
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			// load level 1
			Application.LoadLevel("Level 1");
		}
		else if (Input.GetKeyDown(KeyCode.H)) {
			// load how to play screen
			Application.LoadLevel("How To Play");
		}
		else if (Input.GetKeyDown(KeyCode.C)) {
			// load credits screen
			Application.LoadLevel("Credits");
		}
		else if (Input.GetKeyDown(KeyCode.Escape)) {
			//quit the game
			Application.Quit();
		}
		else if (Input.GetKeyDown(KeyCode.M)) {
			SoundController.toggleSound();
		}
	}

	void OnApplicationQuit () {
		PlayerPrefs.DeleteKey("Screenmanager Resolution Width");
		PlayerPrefs.DeleteKey("Screenmanager Resolution Height");
		PlayerPrefs.DeleteKey("Screenmanager Is Fullscreen mode");
		PlayerPrefs.DeleteKey("UnityGraphicsQuality");
	}
}