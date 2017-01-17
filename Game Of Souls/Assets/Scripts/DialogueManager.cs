using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public GameObject dialogueBox;
	public GameObject dialogueBox1;
	public Text dialogueText;
	private bool dBoxActive = true;
	// Use this for initialization
	void Start () {
		dialogueBox.SetActive (false);
		dialogueBox1.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (dBoxActive && Input.GetKeyDown (KeyCode.Space)) {
			dialogueBox.SetActive (false);
			SceneManager.LoadScene ("Level1");
			dBoxActive = false;
		}
	}
}
