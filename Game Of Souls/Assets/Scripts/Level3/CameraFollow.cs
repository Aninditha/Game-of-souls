using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

//	public GameObject targetObject;
//	private float distanceToTarget;
//	public static bool Move = true;
//
//	// Use this for initialization
//	void Start () {
//		distanceToTarget = transform.position.x - targetObject.transform.position.x;
//	}
		
//	// Update is called once per frame
//	void Update () {
//		if (Move) {
//			float targetObjectX = targetObject.transform.position.x;
//
//			Vector3 newCameraPosition = transform.position;
//			newCameraPosition.x = targetObjectX + distanceToTarget;
//			transform.position = newCameraPosition;
//		}
//	}

//	void Update () {
//		float targetObjectX = targetObject.transform.position.x;
//		//print (targetObjectX+" and "+Variables.lastRoomStartX+" Last scene "+Variables.isLastScene);
//		if (VariablesL3.isLastScene || targetObjectX+(distanceToTarget) < VariablesL3.lastRoomStartX) {
//
//			//print (" stop camera");
//			Vector3 newCameraPosition = transform.position;
//			newCameraPosition.x = targetObjectX + distanceToTarget;
//			transform.position = newCameraPosition;
//		}
//	}

	private Transform player;

	void Start () {
		player = GameObject.Find ("Player").transform;
	}

	void Update () {
		Vector3 playerpos = player.position;
		playerpos.z = transform.position.z;
		transform.position = playerpos;
	}
}