using UnityEngine;
using System.Collections;

public class CameraFollow5 : MonoBehaviour {

	public GameObject targetObject;
	private float distanceToTarget;

	// Use this for initialization
	void Start () {
		distanceToTarget = transform.position.x - targetObject.transform.position.x;
	}

    // Update is called once per frame
    void Update()
    {
        float targetObjectX = targetObject.transform.position.x;
        //print (targetObjectX+" and "+Variables.lastRoomStartX+" Last scene "+Variables.isLastScene);
        if (Variables5.isLastScene || targetObjectX+distanceToTarget < Variables5.lastRoomStartX)
        {

            //print (" stop camera");
            Vector3 newCameraPosition = transform.position;
            newCameraPosition.x = targetObjectX + distanceToTarget;
            transform.position = newCameraPosition;
        }
    }
}
