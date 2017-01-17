using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
	
//[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{
    public bool characterInQuicksand;
    public float maxSpeed = 4f;
    bool faceRight = true;
	public GameObject soul;

    //public float gravity;
    public Boundary boundary;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Animator>().SetFloat("y", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y * y));
		GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * move, GetComponent<Rigidbody2D>().velocity.y);

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
		
		if (col.gameObject.name == "bat") {
			SceneManager.LoadScene("Level1");
		}

		if (col.gameObject.name == "soul") 
		{
			Destroy (col.gameObject);
			SceneManager.LoadScene("InstructionsLevel1");
		}
	}
}
