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

public class GameOver : MonoBehaviour {

	public AudioClip fx_game_over;
	public AudioClip bg_game_over;

	private int score;
	private int best_score;
	private GameObject score_txt;
	private GameObject best_score_txt;

	void Start () {
		score = GameController.score;
		best_score = PlayerPrefs.GetInt("High Score");

		if (score > best_score) {
			best_score = score;
			PlayerPrefs.SetInt("High Score", best_score);
		}

		score_txt = GameObject.Find("ScoreNumber");
		best_score_txt = GameObject.Find("BestScoreNumber");

		score_txt.guiText.text = score.ToString();
		best_score_txt.guiText.text = best_score.ToString();

		if (SoundController.sound_on) {
			AudioSource.PlayClipAtPoint(bg_game_over, new Vector3(0,0,0));
			AudioSource.PlayClipAtPoint(fx_game_over, new Vector3(0,0,0));
		}
	}
}
