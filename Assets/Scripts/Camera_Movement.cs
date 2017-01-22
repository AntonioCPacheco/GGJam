using UnityEngine;
using System.Collections;

public class Camera_Movement : MonoBehaviour {

	public float lookAhead = 3f;
	public float dampTime = 0.15f;

	public bool followPlayer = true;

	Vector3 velocity = Vector3.zero;

	Transform player;
	Vector3 target;

	Camera cam;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;

		target = new Vector3 (player.position.x, player.position.y, player.position.z);

		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (followPlayer) {
            Vector3 aux = player.gameObject.GetComponent<Rigidbody2D>().velocity;
			target = new Vector3 ((player.position.x + lookAhead * aux.x), (player.position.y + lookAhead * aux.y), (player.position.z));

			if (player) {
				Vector3 point = cam.WorldToViewportPoint (target);
				Vector3 delta = target - cam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
				delta = new Vector3(delta.x, delta.y, delta.z);
				Vector3 destination = transform.position + delta;
				//correcting X
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
			}
		}

	}
}
