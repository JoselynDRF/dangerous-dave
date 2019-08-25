using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
	public Image fullBar;

	void Update() {
		fullBar.fillAmount = GameManager.fillBarAmount;
	}
}
