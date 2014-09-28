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

public class ObstacleController : MonoBehaviour {

	public bool isUp = false;

	private float speed = 3f;
	private float min_x = -20f;
	private GameObject bat;
	private bool counted = false;

	void Start () {
		if (isUp) {
			bat = GameObject.Find("Bat");
		}
	}

	void Update () {
		Vector3 newposition = new Vector3();
		newposition = this.transform.position;
		newposition.x = newposition.x - speed * Time.deltaTime;
		
		if (newposition.x < min_x) {
			Destroy(this.gameObject);
		}
		this.transform.position = newposition;

		if (isUp) {
			if (!counted && (bat.transform.position.x > this.transform.position.x)) {
				GameController.score++;
				counted = true;
			}
		}
	}
}
