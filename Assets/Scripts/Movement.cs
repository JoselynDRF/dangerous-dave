using UnityEngine;

public class Movement : MonoBehaviour {
	public float velX = 0.08f;
  public float movX;
  public float currentPosition;
  public bool isLookingRight;

  void Start() { }

  void FixedUpdate() {
    MovePlayer();
  }

  void MovePlayer() {
    float inputX = Input.GetAxis("Horizontal");
    movX = transform.position.x + (inputX * velX);
    currentPosition = movX;

    if (inputX > 0) {
      transform.position = new Vector3(movX, transform.position.y, 0);
      transform.localScale = new Vector3(1, 1, 1);
      isLookingRight = true;
    }

    if (inputX < 0) {
      transform.position = new Vector3(movX, transform.position.y, 0);
      transform.localScale = new Vector3(-1, 1, 1);
      isLookingRight = false;
    }
  }
}
