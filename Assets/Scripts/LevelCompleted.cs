using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class LevelCompleted : MonoBehaviour {
	private Animator animator;
  public Text levelText;
  public Text congratMessage;
  private string sceneName;
  private int currentLevel;
  private int levels = 10;

  void Start() {
    animator = GetComponent <Animator>();
    sceneName = PlayerPrefs.GetString("lastLoadedScene");
    currentLevel = Int32.Parse(Regex.Match(sceneName, @"\d+").Value);

    levelText.text = "LEVEL 0" + currentLevel;
    congratMessage.text = "GOOD WORK! ONLY " + (levels - currentLevel) + " MORE TO GO!";
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
      SceneManager.LoadScene("Level" + (currentLevel + 1));
    }
  }
}
