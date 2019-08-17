using UnityEngine;

public class Gems : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Score.scoreValue += 100;
			Destroy(gameObject);
		}
	}
}
