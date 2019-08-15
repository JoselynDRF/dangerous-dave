using UnityEngine;

public class Movement : MonoBehaviour {
  Animator animator;

	public float velX = 0.08f;
  public float movX;

  void Start() {
    animator = GetComponent <Animator>();
  }

  void FixedUpdate() {
    MovePlayer();
  }

  void MovePlayer() {
    float inputX = Input.GetAxis("Horizontal");
    movX = transform.position.x + (inputX * velX);

    animator.SetFloat("velX", inputX == 0 ? 0 : 1);

    if (inputX > 0) UpdateMovementValues(1);
    if (inputX < 0) UpdateMovementValues(-1);
  }

  void UpdateMovementValues(int scaleX) {
    transform.position = new Vector3(movX, transform.position.y, 0);
    transform.localScale = new Vector3(scaleX, 1, 1);
  }
}
