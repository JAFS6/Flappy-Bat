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

public class PlayerController : MonoBehaviour {

	bool started;
	float flap_force = 200f;
	float y_max = 4.5f;
	float y_min = -5f;
	Animator anim;
	GameObject starthint;
	
	void Start () {
		anim = GetComponent<Animator>();
		starthint = GameObject.Find("StartHint");
		Vector3 hintpos = new Vector3();
		hintpos = starthint.transform.position;
		hintpos.y = 0.7f;
		starthint.transform.position = hintpos;
		started = false;
	}

	void Update () {

		Vector3 position = new Vector3();
		position = this.transform.position;

		if (position.y > y_max) {
			position.y = y_max;
			this.transform.position = position;
		}
		else  if(position.y < y_min) {
			Application.LoadLevel("Game Over");
		}
		else if( started && Input.GetKeyDown(KeyCode.Space) ) {
			anim.SetTrigger("Flap");
			rigidbody2D.AddForce(new Vector2(0,flap_force));
		}
		else if( !started && Input.GetKeyDown(KeyCode.Space) ) {
			anim.SetTrigger("Flap");
			rigidbody2D.AddForce(new Vector2(0,flap_force));
			started = true;
			rigidbody2D.gravityScale = 0.4f;
			anim.SetBool("Started",true);
			Vector3 hintpos = new Vector3();
			hintpos = starthint.transform.position;
			hintpos.y += 3;
			starthint.transform.position = hintpos;
		}
	}
}
