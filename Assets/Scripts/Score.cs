using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private Text score;

	void Start() {
		score = GetComponent<Text>();
	}

	void Update() {
		score.text = "SCORE: " + GameManager.score;
	}
}
