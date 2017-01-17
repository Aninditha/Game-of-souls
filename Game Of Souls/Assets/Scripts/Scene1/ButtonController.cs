using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    // Use this for initialization
    //public Canvas GameInstructions;
    //public Button OKButton;
    public GameObject Image;
	private bool click = true;
    
    void Start ()
    {
       // OKButton = OKButton.GetComponent<Button>();
        Image.SetActive(true);
        
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (click && (Input.GetKeyDown (KeyCode.Space))|| (Input.GetKeyDown (KeyCode.KeypadEnter))) {
			Image.SetActive (false);
			click = false;		
		}
	}

	public void OKPress()
    {
        Image.SetActive(false);
    }



}
