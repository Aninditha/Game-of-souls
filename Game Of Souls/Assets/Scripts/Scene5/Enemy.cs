using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//public Sprite bat;
	public float speed;
	//public Boundary boundary;
	private bool facingRight=false;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (GetComponent<SpriteRenderer> ().name == "Frog") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed,GetComponent<Rigidbody2D> ().velocity.y);
			float yPose = GetComponent<Rigidbody2D> ().position.y;
			GetComponent<Rigidbody2D>().position  = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, -3, 3),yPose);
			float pos = GetComponent<Rigidbody2D> ().position.x;

			if((pos==3&& !facingRight)||(pos==-3&& facingRight)){
				FlipFrog ();
			}
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, speed);
			float xPose = GetComponent<Rigidbody2D> ().position.x;
			GetComponent<Rigidbody2D>().position  = new Vector2(xPose,Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, -3, 3));
			float pos = GetComponent<Rigidbody2D> ().position.y;

			if((pos==3&& facingRight)||(pos==-3&&!facingRight)){
				FlipFish ();
			}
		}


	}

	void OnCollisionEnter2D(Collision2D o){
		//print (o.gameObject.name);
		if (o.gameObject.name == "Plant") {
			if (speed < 0 && !facingRight) {
				if (GetComponent<SpriteRenderer> ().name == "Fish")
					FlipFish ();
				else
					FlipFrog ();
			} else if (speed > 0 && facingRight) {
				if (GetComponent<SpriteRenderer> ().name == "Fish")
					FlipFish ();
				else
					FlipFrog ();
			}
		} else if (o.gameObject.name == "Frog") {
			if (speed < 0 && !facingRight) {
				if (GetComponent<SpriteRenderer> ().name == "Fish")
					FlipFish ();
				else
					FlipFrog ();
			} else if (speed > 0 && facingRight) {
				if (GetComponent<SpriteRenderer> ().name == "Fish")
					FlipFish ();
				else
					FlipFrog ();
			}
		}
	}

	void FlipFish(){
		facingRight = !facingRight;
		Vector3 thescale = transform.localScale;

		thescale.y *= -1;
		transform.localScale = thescale;
		speed = -speed;

	}
	void FlipFrog(){
		facingRight = !facingRight;
		Vector3 thescale = transform.localScale;

		thescale.x *= -1;
		transform.localScale = thescale;
		speed = -speed;

	}
}
