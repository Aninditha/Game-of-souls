using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject StartButton;
	private bool click=true;
    //public Text
    //private Button startText;
    

	// Use this for initialization
	void Start ()
    {
		StartButton.SetActive (true);
		//startText = startText.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (click && (Input.GetKeyDown (KeyCode.Space))|| (Input.GetKeyDown (KeyCode.KeypadEnter))) {
			StartButton.SetActive (false);
			SceneManager.LoadScene ("Instructions");
			click = false;		
		}
    }

    public void StartLevel()
    {
		SceneManager.LoadScene ("Instructions");
        //Application.LoadLevel(1);
    }
}
