using UnityEngine;
using System.Collections;

public class MovingFish : MonoBehaviour {

	public Vector3 targetPosition = new Vector3();
	private Vector3 startPosition = new Vector3();
	public Transform target;
	public float speed = 1.0f;
	private float threshold = 0.5f;
	private bool flip = true;

	void Start() {
		startPosition.x = target.position.x;
		startPosition.y = target.position.y;
	}

	void Update () {
		if (flip) {
			Vector3 direction = targetPosition - transform.position;
			if (direction.magnitude > threshold) {
				direction.Normalize ();
				transform.position = transform.position + direction * speed * Time.deltaTime;
			} else { 
				// Without this game object jumps around target and never settles
				transform.position = targetPosition;
				flip = false;
			}
		} else {
			transform.position = startPosition;
			flip = true;
		}
	}
}