using UnityEngine;

public class Gems : MonoBehaviour {
	private int blueScore = 100;
	private int redScore = 150;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Score.scoreValue += gameObject.tag == "RedGem" ? redScore : blueScore;
			Destroy(gameObject);
		}
	}
}
