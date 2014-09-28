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

public class BackgroundController : MonoBehaviour {

	float speed = 1f;
	float min_x = -30f;
	
	// Update is called once per frame
	void Update () {
		Vector3 newposition = new Vector3();
		newposition = this.transform.position;
		newposition.x = newposition.x - speed * Time.deltaTime;

		if(newposition.x < min_x) {
			newposition.x = 49.9f;
		}

		this.transform.position = newposition;
	}
}