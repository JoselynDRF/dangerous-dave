﻿using UnityEngine;

public class Bullet : MonoBehaviour {
	Rigidbody2D rigidbodyBullet;
	public float speed;

	void Start() {
		rigidbodyBullet = GetComponent<Rigidbody2D>();
	}

	void Update() {
		rigidbodyBullet.velocity = new Vector2(speed, 0);
	}
}