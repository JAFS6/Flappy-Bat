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

public class CreditsController : MonoBehaviour {

	private AudioSource bg_music;
	
	void Start () {
		bg_music = GetComponent<AudioSource>();
		
		if (SoundController.sound_on) {
			bg_music.mute = false;
		}
		else {
			bg_music.mute = true;
		}
	}

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// load main menu
			Application.LoadLevel("Main Menu");
		}
	}
}
