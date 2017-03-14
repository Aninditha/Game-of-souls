using UnityEngine;
using System.Collections;

public class BatReverse : MonoBehaviour {
	public float speed=-3f;
	public Boundary boundary;
	private bool facingRight=false;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		float yPose = GetComponent<Rigidbody2D> ().position.y;
		GetComponent<Rigidbody2D>().position = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(yPose,yPose , yPose));
		float pos = GetComponent<Rigidbody2D> ().position.x;
		//print (pos+" and "+facingRight);
		if((pos==boundary.xMax && facingRight)||(pos==boundary.xMin &&!facingRight)){
			Flip ();

		}

	}

	void OnCollisionEnter2D(Collision2D o){
		if (o.gameObject.name == "Cube") {
			if (speed < 0 && !facingRight)
				Flip();
			else if (speed > 0 && facingRight)
				Flip();
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 thescale = transform.localScale;

		thescale.x *= -1;
		transform.localScale = thescale;
		speed = -speed;

	}
}
