using UnityEngine;
using System.Collections;

[System.Serializable]
/*public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}*/
public class ReaperController : MonoBehaviour
{

    public float speed;
   // public Boundary boundary;
   // public float tilt;
    // Use this for initialization
    //For Fire shot
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private bool fire = true;

    void FixedUpdate()
    {
       // float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0.0f, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

            
        
        /*  GetComponent<Rigidbody>().position = new Vector3
              (
              Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
              0.0f,
              Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
              );*/

        // GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > (fireRate*2))
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
