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

public class SoundController : MonoBehaviour {

	static public bool sound_on = true;

	public bool isMute = false;
	public bool isUnmute = false;
	
	static private GameObject mute;
	static private GameObject unmute;

	void Start () {
		mute = GameObject.Find("Mute");
		unmute = GameObject.Find("Unmute");
		
		Vector3 pos_mute = new Vector3();
		pos_mute = mute.transform.position;
		
		Vector3 pos_unmute = new Vector3();
		pos_unmute = unmute.transform.position;
		
		if (sound_on) { // If sound is on
			// Put mute icon
			pos_mute.z = 0;
			pos_unmute.z = 10;
		}
		else { // If sound is off
			// Put unmute icon
			pos_mute.z = 10;
			pos_unmute.z = 0;
		}
		
		mute.transform.position = pos_mute;
		unmute.transform.position = pos_unmute;
	}

	void OnMouseUp () {
		toggleSound();
	}

	static public void toggleSound () {
		
		Vector3 pos_mute = new Vector3();
		pos_mute = mute.transform.position;
		
		Vector3 pos_unmute = new Vector3();
		pos_unmute = unmute.transform.position;
		
		if (sound_on) { // If sound was on
			// Put unmute icon
			pos_mute.z = 10;
			pos_unmute.z = 0;
		}
		else { // If sound was off
			// Put mute icon
			pos_mute.z = 0;
			pos_unmute.z = 10;
		}
		
		mute.transform.position = pos_mute;
		unmute.transform.position = pos_unmute;
		
		sound_on = !sound_on; // Change state
	}
}
