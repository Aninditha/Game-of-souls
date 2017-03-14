using UnityEngine;
using System.Collections;

public class Mover5 : MonoBehaviour {


    public float speed;
    // Use this for initialization
    //for fire shot
    
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	
	}
}

