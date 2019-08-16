using UnityEngine;

public class Gems : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy(gameObject);
		}
	}
}
