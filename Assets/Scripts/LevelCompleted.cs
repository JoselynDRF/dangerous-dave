using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour {
	private Animator animator;

  void Start() {
    animator = GetComponent <Animator>();
  }

	void FixedUpdate() {
		transform.position = new Vector3(transform.position.x + 0.09f, transform.position.y, 0);
		animator.SetFloat("velX", 1);
		animator.SetBool("grounded", true);
	}

	void OnTriggerEnter2D(Collider2D other) {
    string tag = other.gameObject.tag;
    GoToNextLevel(tag);
  }

	void GoToNextLevel(string tag) {
    if (tag == "Door") {
      SceneManager.LoadScene("Level2");
    }
  }
}
