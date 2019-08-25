using UnityEngine;
using UnityEngine.UI;

public class JetPackBar : MonoBehaviour {
	public Image fullBar;

	void Update() {
		fullBar.fillAmount = GameManager.fillBarAmount;
	}
}
