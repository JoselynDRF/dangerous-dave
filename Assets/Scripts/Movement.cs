using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Movement : MonoBehaviour {
  private Animator animator;
  private Rigidbody2D rigidbodyPlayer;

  // Move
	public float velocity = 0.08f;
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

  // Died
  private float initialPositionX;
  private float initialPositionY;

  // JetPack
  public GameObject progressBar;
  private float barSpeed = 15f;
  private bool hasJetPack;
  private bool isJetPackOn;

  void Start() {
    animator = GetComponent<Animator>();
    rigidbodyPlayer = GetComponent<Rigidbody2D>();
    goToDoorText.SetActive(false);
    progressBar.SetActive(false);
    hasKey = false;

    initialPositionX = transform.position.x;
    initialPositionY = transform.position.y;
  }

  void FixedUpdate() {
    MovePlayerX();
    JumpPlayer();
    UseJetPack();
  }

  void MovePlayerX() {
    float inputX = Input.GetAxis("Horizontal");
    movX = transform.position.x + (inputX * velocity);

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

    if (grounded && Input.GetKeyDown(KeyCode.UpArrow) && !isJetPackOn) {
      rigidbodyPlayer.AddForce(new Vector2(0, jumpForce));
    }

    animator.SetBool("grounded", grounded);
  }

  void OnTriggerEnter2D(Collider2D other) {
    string tag = other.gameObject.tag;
    GetTrophy(tag);
    GetJetPack(other);
    GoToNextLevel(tag);
  }

  void OnCollisionEnter2D(Collision2D other) {
    string tag = other.gameObject.tag;
    GetDied(tag);
  }

  void GetTrophy(string tag) {
    if (tag == "Trophy") {
      goToDoorText.SetActive(true);
      hasKey = true;
    }
  }

  void GetJetPack(Collider2D jetPack) {
    if (jetPack.gameObject.tag == "JetPack") {
      hasJetPack = true;
      Destroy(jetPack.gameObject);
      progressBar.SetActive(true);
    }
  }

  void UseJetPack() {
    if (Input.GetKeyDown(KeyCode.Space) && hasJetPack) {
      HandleJetPack();
      rigidbodyPlayer.velocity = Vector3.zero;
    }

    if (isJetPackOn) {
      MovePlayerY();
      FillJetPackBar();
    }
  }

  void MovePlayerY() {
    float inputY = Input.GetAxis("Vertical");
    float movY = transform.position.y + (inputY * velocity);
    transform.position = new Vector3(transform.position.x, movY, 0);
  }

  void FillJetPackBar() {
    GameManager.fillBarAmount -= Time.deltaTime / barSpeed;

    if (GameManager.fillBarAmount <= 0) {
      hasJetPack = false;
      progressBar.SetActive(false);
      HandleJetPack();
    }
  }

  void HandleJetPack() {
    isJetPackOn = !isJetPackOn;
    animator.SetBool("jetpack", isJetPackOn);
    rigidbodyPlayer.gravityScale = isJetPackOn ? 0 : 1;
  }

  void GoToNextLevel(string tag) {
    if (tag == "Door" && hasKey) {
      PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
      SceneManager.LoadScene("LevelCompleted");
    }
  }

  void GetDied(string tag) {
    if (tag == "Enemies") {
      if (GameManager.lives > 0) {
        GameManager.lives -= 1;
        animator.SetBool("died", true);
        this.enabled = false;
        StartCoroutine(RestartPlayer());
      } else {
        SceneManager.LoadScene("GameOver");
        GameManager.lives = 3;
        GameManager.score = 0;
      }
    }
  }

  public IEnumerator RestartPlayer() {
    yield return new WaitForSeconds(1.5f);
    animator.SetBool("died", false);
    transform.position = new Vector3(initialPositionX, initialPositionY, 0);
    this.enabled = true;
    if (isJetPackOn) HandleJetPack();
  }
}
