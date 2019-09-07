using UnityEngine;

public class SpiderAI : MonoBehaviour {
	public Transform[] spiderPoints;
	public GameObject shot;
	private int currentIndex = 0;
	private float speed = 4f;
	public bool allowToShoot;

	void Start() {
		GameManager.isEnemyFrozen = false;
	}

	void FixedUpdate() {
		if (!GameManager.isEnemyFrozen) MoveSpider();
		if (GameManager.shotEnabled) allowToShoot = true;
	}
	
	void MoveSpider() {
		transform.position = Vector2.MoveTowards(
			transform.position,
			spiderPoints[currentIndex].transform.position,
			speed * Time.deltaTime
		);

		if (transform.position == spiderPoints[currentIndex].transform.position) currentIndex++;
		if (currentIndex == spiderPoints.Length) currentIndex = 0;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "FirePoint" && allowToShoot) {
			Instantiate(shot, gameObject.transform.position, Quaternion.identity);
		}
	}
}
