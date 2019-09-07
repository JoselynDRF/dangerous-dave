using UnityEngine;

public class Shot : MonoBehaviour {
	Rigidbody2D rigidbodyShot;
	private float speed = -8f;

	void Start() {
		rigidbodyShot = GetComponent<Rigidbody2D>();
		rigidbodyShot.velocity = new Vector2(speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Player") {
			Destroy(gameObject);
		}
	}
}
