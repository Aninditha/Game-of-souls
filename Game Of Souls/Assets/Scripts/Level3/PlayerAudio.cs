using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {

	public AudioClip clip;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag ("stars")) {
			AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
		}
	}
}
