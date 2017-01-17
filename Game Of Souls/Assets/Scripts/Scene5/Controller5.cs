using UnityEngine;
using System.Collections;

public class Controller5 : MonoBehaviour
{

    public float jumpHeight;
    private bool isJumping = false;
    private bool grounded = false;
    public float speed;
    private float nextJump;
    public float JumpInt;
    
    private float moveVelocity;

  //  public GameObject shot;
  //  public Transform FireSpawn;
   // public float fireRate;
   // private float nextFire;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Jumping Section
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && Time.time > nextJump)
        {
            if (isJumping == false)
            {
                nextJump = Time.time + JumpInt; 
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, speed + jumpHeight);
                isJumping = true;
            }
            else if (!grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, speed + jumpHeight);
                isJumping = false;
                
            }

        }

        /*if((Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.S)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, FireSpawn.position, FireSpawn.rotation);

        }*/

        
        moveVelocity = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            moveVelocity = -speed;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            moveVelocity = speed;
    }

    //this bit is to check if the object that collided with it has the ground tag

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isJumping = false;
            grounded = true;
        }
        
    }
   

}
