using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {
	Rigidbody2D rigidbodyBullet;
	public float speed;

	void Start() {
		rigidbodyBullet = GetComponent<Rigidbody2D>();
	}

	void Update() {
		rigidbodyBullet.velocity = new Vector2(speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Wall") {
			Destroy(gameObject);
		}

		if (other.gameObject.tag == "Monsters" && !GameManager.isEnemyFrozen) {
			StartCoroutine(DestroyMonster(other));
		}
	}

	public IEnumerator DestroyMonster(Collider2D monster) {
		Animator monsterAnimator = monster.gameObject.GetComponent<Animator>();
		monsterAnimator.SetBool("died", true);
		GameManager.isEnemyFrozen = true;
    yield return new WaitForSeconds(1.5f);
		GameManager.isEnemyFrozen = false;
  	Destroy(monster.gameObject);
  }
}
