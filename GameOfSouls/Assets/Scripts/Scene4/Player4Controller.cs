using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player4Controller : MonoBehaviour {

	private KeyCode pressedKey;
	public float speed;
	public float jump;
	bool grounded;
	//private bool characterInQuicksand = true;
	//private int count = 0;
	// public Text text;

	private float moveVelocity;


	//bool grounded = true;
	// Use this for initialization
	void Start ()
	{
		grounded = true;
	}

	// Update is called once per frame
	void Update ()
	{
		//characterInQuicksand = true;   
		//if(characterInQuicksand)
		//{

		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(grounded){
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -jump);
				//characterInQuicksand = false;
				grounded=false;
			}
		}

		//}
		moveVelocity = 0;

		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			moveVelocity = speed;
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			moveVelocity = -speed;


		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

	}

	void OnCollisionEnter2D()
	{
		grounded = true;
	}

	void OnCollisionExit2D()
	{
		grounded = false;
	}

}
