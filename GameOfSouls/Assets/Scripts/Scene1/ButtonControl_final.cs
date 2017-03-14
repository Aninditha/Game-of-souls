using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonControl_final : MonoBehaviour
{

    // Use this for initialization
    //public Canvas GameInstructions;
    //public Button OKButton;
    public GameObject FinalText;
    private bool click = true;
    private PlayerController playercontrol;

    void Start()
    {
        // OKButton = OKButton.GetComponent<Button>();
        FinalText.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OKPress()
    {
        FinalText.SetActive(false);
        SceneManager.LoadScene(3);
    }





}
