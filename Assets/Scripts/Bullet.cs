﻿using System.Collections;
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

		if (other.gameObject.tag == "Monsters") {
			StartCoroutine(DestroyMonster(other));
		}
	}

	public IEnumerator DestroyMonster(Collider2D monster) {
		Animator monsterAnimator = monster.gameObject.GetComponent<Animator>();
		monsterAnimator.SetBool("died", true);
    yield return new WaitForSeconds(1.5f);
  	Destroy(monster.gameObject);
  }
}
