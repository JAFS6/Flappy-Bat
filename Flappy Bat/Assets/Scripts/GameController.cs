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
	static public int score;

	//public GameObject Player;				// Player prefab
	public GameObject Obstacle_A_Up;		// Obstacle A Up prefab
	public GameObject Obstacle_A_Down;		// Obstacle A Down prefab
	public GameObject Obstacle_B_Up;		// Obstacle B Up prefab
	public GameObject Obstacle_B_Down;		// Obstacle B Down prefab
	public GameObject Obstacle_C_Up;		// Obstacle C Up prefab
	public GameObject Obstacle_C_Down;		// Obstacle C Down prefab
	public GameObject Obstacle_D_Up;		// Obstacle D Up prefab
	public GameObject Obstacle_D_Down;		// Obstacle D Down prefab
	public GameObject Obstacle_E_Up;		// Obstacle E Up prefab
	public GameObject Obstacle_E_Down;		// Obstacle E Down prefab

	private float delayBetweenSpawns = 1.8f;// Delay between obstacle spawns
	private GameObject[,] obstacle;			// Obstacles 2D matrix, m[i,Up], m[i,Down]
	private GameObject starthint;
	private GameObject score_txt;
	private GameObject bat;
	private Animator bat_animator;
	private float spawnTimer;				// Obstacles Spawn timer
	
	void Start () {

		// Spawn player
		//Vector3 pos = new Vector3(-3.63f, 0, 0);		// Set position of the spawn
		//Instantiate(Player, pos, Quaternion.identity);	// Spawn player

		// Fill obstacles matrix
		obstacle = new GameObject[5,2];
		obstacle[0,0] = Obstacle_A_Up;
		obstacle[0,1] = Obstacle_A_Down;
		obstacle[1,0] = Obstacle_B_Up;
		obstacle[1,1] = Obstacle_B_Down;
		obstacle[2,0] = Obstacle_C_Up;
		obstacle[2,1] = Obstacle_C_Down;
		obstacle[3,0] = Obstacle_D_Up;
		obstacle[3,1] = Obstacle_D_Down;
		obstacle[4,0] = Obstacle_E_Up;
		obstacle[4,1] = Obstacle_E_Down;


		starthint = GameObject.Find("StartHint");
		Vector3 hintpos = new Vector3();
		hintpos = starthint.transform.position;
		hintpos.y = 0.7f;
		starthint.transform.position = hintpos;

		score_txt = GameObject.Find("ScoreNumber");
		score_txt.guiText.text = "0";
		score = 0;

		bat = GameObject.Find("Bat");
		bat_animator = bat.GetComponent<Animator> ();

		started = false;
	}
	
	void Update () {

		if (started) {

			// Update score
			score_txt.guiText.text = score.ToString();

			// Update time passed
			spawnTimer += Time.deltaTime;
			
			if (spawnTimer > delayBetweenSpawns) {
				SpawnObstacle();
				spawnTimer = 0f;
			}
		}
		else if (!started && Input.GetKeyDown(KeyCode.Space)) {
			// Hide start hint
			Vector3 hintpos = new Vector3();
			hintpos = starthint.transform.position;
			hintpos.y += 3;
			starthint.transform.position = hintpos;
			// Set started game to true
			started = true;
			// Make bat be affected by gravity
			bat.rigidbody2D.gravityScale = 0.7f;
			// Tell the bat animator, the game has started
			bat_animator.SetBool("Started",true);
			// Spawn first obstacle
			SpawnObstacle();
		}
	}

	void SpawnObstacle () {

		int obst = Random.Range(0, 5);

		Vector3 pos = new Vector3(10, 2, 0);						// Set position of the spawn
		Instantiate(obstacle[obst,0], pos, Quaternion.identity);	// Spawn obstacle upper part
		pos = new Vector3(10, -2, 0);								// Set position of the spawn
		Instantiate(obstacle[obst,1], pos, Quaternion.identity);	// Spawn obstacle lower part
	}
}
