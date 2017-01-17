using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "SeaBed")
			SceneManager.LoadScene("UnderwaterLevel");
		else if (col.gameObject.name == "Fish")
			SceneManager.LoadScene("UnderwaterLevel");
		else if (col.gameObject.name == "soul")
			SceneManager.LoadScene("InstructionsLevel2");
	}
}
