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

		AudioSource.PlayClipAtPoint(bg_game_over, new Vector3(0,0,0));
		AudioSource.PlayClipAtPoint(fx_game_over, new Vector3(0,0,0));
	}
}
