using UnityEngine;
using System.Collections;

public class Skeleton : MonoBehaviour
{

    public int Health = 100;
    public float speed = -5f;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    /*public void OnCollisionEnter2D(Collision2D other)
    {
        print("On Collision "+other.gameObject.name);
        if (other.gameObject.name == "laser")
        {
            
            Health -= 100;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }*/
}
