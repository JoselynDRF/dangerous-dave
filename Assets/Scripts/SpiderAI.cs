using UnityEngine;

public class SpiderAI : MonoBehaviour {
	public Transform[] spiderPoints;
	private int currentIndex = 0;
	private float speed = 4f;

	void Start() {
		GameManager.isEnemyFrozen = false;
	}

	void FixedUpdate() {
		if (!GameManager.isEnemyFrozen) MoveSpider();
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
}
