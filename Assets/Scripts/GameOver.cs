using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	void FixedUpdate() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			SceneManager.LoadScene("Level1");
		}
	}
}
