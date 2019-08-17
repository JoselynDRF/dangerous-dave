using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private Text score;
	public static int scoreValue = 0;

	void Start() {
		score = GetComponent<Text>();
	}

	void Update() {
		score.text = "SCORE: " + scoreValue;
	}
}
