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
					Score.scoreValue += purpleScore;
					break;
				case "RedGem":
					Score.scoreValue += redScore;
					break;
				case "Trophy":
					Score.scoreValue += trophyScore;
					break;
				default:
					Score.scoreValue += blueScore;
					break;
			}

			Destroy(gameObject);
		}
	}
}
