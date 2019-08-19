using UnityEngine;

public class CameraFollow : MonoBehaviour {
  public GameObject player;
	public Vector2 minCameraPosition;
	public Vector2 maxCameraPosition;

	void FixedUpdate() {
		float cameraPositionX = Mathf.Clamp(player.transform.position.x, minCameraPosition.x, maxCameraPosition.x);
		transform.position = new Vector3(cameraPositionX, transform.position.y, transform.position.z);
	}
}
