using UnityEngine;

public class Movement : MonoBehaviour {
  private Animator animator;
  private Rigidbody2D rigidbodyPlayer;

  // Move
	public float velX = 0.08f;
  public float movX;

  // Jump
  public Transform groundCheck;
  public LayerMask groundLayer;
  public float jumpForce = 350f;
  public float groundCheckRadio = 0.08f;
  public bool grounded;

  // Win level
  public GameObject goToDoorText;
  public bool hasKey;

  void Start() {
    animator = GetComponent <Animator>();
    rigidbodyPlayer = GetComponent <Rigidbody2D>();
    goToDoorText.SetActive(false);
    hasKey = false;
  }

  void FixedUpdate() {
    MovePlayer();
    JumpPlayer();
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

  void JumpPlayer() {
    grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadio, groundLayer);

    if (grounded && Input.GetKeyDown(KeyCode.UpArrow)) {
      rigidbodyPlayer.AddForce(new Vector2(0, jumpForce));
    }

    animator.SetBool("grounded", grounded);
  }

  void OnTriggerEnter2D(Collider2D other) {
    string tag = other.gameObject.tag;
    GetTrophy(tag);
    GoToNextLevel(tag);
  }

  void GetTrophy(string tag) {
    if (tag == "Trophy") {
      goToDoorText.SetActive(true);
      hasKey = true;
    }
  }

  void GoToNextLevel(string tag) {
    if (tag == "Door" && hasKey) {
      Debug.Log("NEXT LEVEL");
    }
  }
}
