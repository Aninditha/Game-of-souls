using UnityEngine;
using System.Collections;

public class PlayerControllerL3 : MonoBehaviour {

	float speed = 4f;

	void FixedUpdate () {

		if (Input.GetKey (KeyCode.RightArrow)) {
			Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
			newVelocity.x = speed;
			GetComponent<Rigidbody2D>().velocity= newVelocity;    
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
			newVelocity.x = speed;
			GetComponent<Rigidbody2D>().velocity= -newVelocity;     
		}
		else if (Input.GetKey (KeyCode.UpArrow)) {
			Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
			newVelocity.y = speed;
			GetComponent<Rigidbody2D>().velocity= newVelocity; 
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
			newVelocity.y = speed;
			GetComponent<Rigidbody2D>().velocity= -newVelocity;
		}
	}
}