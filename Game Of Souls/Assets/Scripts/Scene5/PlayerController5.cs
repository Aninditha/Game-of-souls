using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]


//[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController5 : MonoBehaviour
{
    public bool characterInQuicksand;
    public float maxSpeed = 4f;
    bool faceRight = true;
    //private int souls = 0;
   // public Texture2D soulTexture;
    public int Health = 100;
    //private Text text;
    //public float gravity;
    //public Boundary boundary;
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

        GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * move, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Animator>().SetFloat("y", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y * y));

        if (move > 0 && !faceRight)
            Flip();
        else if (move < 0 && faceRight)
            Flip();

        //GetComponent<Rigidbody2D>().position = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
        //    Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax));

        
    }



        void Flip()
        {
        faceRight = !faceRight;
        Vector3 thescale = transform.localScale;

        thescale.x *= -1;
        transform.localScale = thescale;
        }

    

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "enemy")
        {
            Health -= 100;
            if (Health <= 0)
            {
                Destroy(gameObject);
                
                SceneManager.LoadScene(0);
            }
                 
            //souls++;
            //text.text = souls.ToString();
        }
        else if(other.gameObject.name == "Reaper")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }

        

    }

  /*  void DisplayCoinsCount()
    {
        Rect coinIconRect = new Rect(10, 10, 32, 32);
        GUI.DrawTexture(coinIconRect, soulTexture);

        GUIStyle style = new GUIStyle();
        
        style.fontSize = 30;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.red;

        Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
        GUI.Label(labelRect, souls.ToString(), style);
    }

    void OnGUI()
    {
        DisplayCoinsCount();
    }*/

}
