using UnityEngine;

public class Gems : MonoBehaviour {
	private int purpleScore = 50;
	private int blueScore = 100;
	private int redScore = 150;
	private int trophyScore = 1000;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {

			switch (gameObject.tag)	{
				case "PurpleGem":
					GameManager.score += purpleScore;
					break;
				case "RedGem":
					GameManager.score += redScore;
					break;
				case "Trophy":
					GameManager.score += trophyScore;
					break;
				default:
					GameManager.score += blueScore;
					break;
			}

			Destroy(gameObject);
		}
	}
}
