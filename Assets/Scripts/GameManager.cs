using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager instance = null;
  public static int lives = 3;
  public static int score = 0;

  void Awake() {
    if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

    DontDestroyOnLoad(gameObject);
  }
}
