using UnityEngine;

public class Lives : MonoBehaviour {
	public GameObject live1;
	public GameObject live2;
	public GameObject live3;

	void Update() {
		switch (GameManager.lives) {
			case 0:
				live1.SetActive(false);
				live2.SetActive(false);
				live3.SetActive(false);
				break;
			case 1:
				live2.SetActive(false);
				live3.SetActive(false);
				break;
			case 2:
				live3.SetActive(false);
				break;
		}
	}
}
