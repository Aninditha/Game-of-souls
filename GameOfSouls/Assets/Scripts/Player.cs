using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float maxSpeed = 4f;
	bool faceRight = true, show = true, load = false;
//	public DialogueManager dm;
	public GameObject dialogueBox;
	public GameObject dialogueBox1;

	// Use this for initialization
	void Start()
	{
//		dm = FindObjectOfType<DialogueManager> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (load) {
			if (Input.GetKey (KeyCode.Space))
				SceneManager.LoadScene ("Level1");
		}
	}

	void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");
		if (move > 0) {
			show = false;
		}

		GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(move));
		GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * move, GetComponent<Rigidbody2D>().velocity.y);

		if (!show) {
			dialogueBox1.SetActive(false);
		}


		if (move > 0 && !faceRight)
			Flip();
		else if (move < 0 && faceRight)
			Flip();
	}

	void Flip()
	{
		faceRight = !faceRight;
		Vector3 thescale = transform.localScale;

		thescale.x *= -1;
		transform.localScale = thescale;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "enemy") {
			dialogueBox.SetActive (true);
			load = true;
		}
	}
}