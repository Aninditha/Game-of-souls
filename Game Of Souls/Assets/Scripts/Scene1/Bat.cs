using UnityEngine;
using System.Collections;

[System.Serializable]
/*public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}
*/
public class Bat : MonoBehaviour {
	//public Sprite bat;
	public float speed=-3f;
	public Boundary boundary;
	private bool facingRight=false;
	// Use this for initialization
	void Start () {
		/*for (int y = 0; y < 5; y++) {
			for (int x = 0; x < 5; x++) {
				GameObject cube = GameObject.Find("bat13");
				cube.transform.localScale.Set (15, 50, 0);
				//cube.transform.y = 5;
				cube.AddComponent<Rigidbody>();
				cube.GetComponent<Rigidbody> ().useGravity = false;

				Vector3 newPos = new Vector3(10.0f,2.0f,0f);
				cube.transform.position = new Vector3(x, y, 0);
				cube.AddComponent<BoxCollider2D> ();
				cube.GetComponent<Rigidbody>().AddForce(Vector3.up*10);
				//myGameObject.transform.position = newPos;
*/
//			}
	//	}
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		float yPose = GetComponent<Rigidbody2D> ().position.y;
		GetComponent<Rigidbody2D>().position = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(yPose,yPose , yPose));
		float pos = GetComponent<Rigidbody2D> ().position.x;

		if((pos==8&& facingRight)||(pos==-8&&!facingRight)){
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
