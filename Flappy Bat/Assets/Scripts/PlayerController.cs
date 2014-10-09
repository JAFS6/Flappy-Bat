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

	public AudioClip fx_impact;
	public AudioClip fx_flap;
	static public bool dead;

	private float flap_force = 200f;
	private float y_max = 4.5f;
	private float y_min = -5f;
	private Animator anim;
	
	void Start () {
		anim = GetComponent<Animator>();
		dead = false;
	}

	void Update () {

		if (!dead) {
			Vector3 position = new Vector3();
			position = this.transform.position;

			if (position.y > y_max) {
				position.y = y_max;
				this.transform.position = position;
				rigidbody2D.velocity = new Vector2(0,0);
			}
			else if (position.y < y_min) {
				dead = true;
				Application.LoadLevel("Game Over");
			}
			else if (GameController.started && Input.GetKeyDown(KeyCode.Space)) {

				if (SoundController.sound_on) {
					AudioSource.PlayClipAtPoint(fx_flap, this.transform.position);
				}
				anim.SetTrigger("Flap");
				rigidbody2D.AddForce(new Vector2(0,flap_force));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (SoundController.sound_on) {
			AudioSource.PlayClipAtPoint(fx_impact, this.transform.position);
		}
		dead = true;
		Invoke("goGameOver", 0.5f);
	}

	void goGameOver () {
		Application.LoadLevel("Game Over");
	}
}
