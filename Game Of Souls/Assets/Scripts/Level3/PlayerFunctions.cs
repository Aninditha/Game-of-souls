using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFunctions : MonoBehaviour {

	private static float stars = 0;
	private static float totalStars = 40;
	public Image content;
	public Text valueText;
	public Color fullColor;
	public Color lowColor;
	public bool finish = false;
	public SpriteRenderer soulSprite;
	private Vector3 soulPosition = new Vector3();
	private Vector3 playerPosition = new Vector3();

	// Use this for initialization
	void Start () {
		HandleBar (stars);
		soulSprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (!finish) {
			if(col.gameObject.name == "comet")
				HitByObject();
			else if(col.gameObject.name == "Astroid")
				HitByObject();
			else if(col.gameObject.name == "Planet")
				HitByObject();
			else if(col.gameObject.name == "spacecraft")
				HitByObject();
			else if(col.gameObject.name == "Jet")
				HitByObject();
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("stars"))
			CollectStars(collider);
		else if (collider.gameObject.CompareTag("soul")) {
			print ("soul");
			SceneManager.LoadScene("InstructionsLevel3");
		}
	}

	void CollectStars(Collider2D starCollider)
	{
		Destroy(starCollider.gameObject);
		if (!finish) {
			++stars;
			totalStars--;

			if (totalStars == 0) {
				print ("out of stars");
				SceneManager.LoadScene("NewSpaceLevel");
			} else
				HandleBar (stars);
		}
	}

	void HitByObject()
	{
		if (stars >= 5)
			stars = stars - 5;
		else
			stars = 0;

		HandleBar (stars);
	}

	public void HandleBar(float Value){

		float progress = Map (Value, 0, 10, 0, 1);
		print (progress);

		if (progress <= 1) {
			string[] tmp = valueText.text.Split (':');
			valueText.text = tmp [0] + ": " + Value;
			content.fillAmount = progress;
		} else {
			print ("finished");
			finish = true;
			DisplaySoul ();
		}
		content.color = Color.Lerp (lowColor, fullColor, progress);
	}

	public void DisplaySoul(){
		playerPosition = GameObject.Find ("Player").transform.position;

		soulPosition.x = Random.Range(-59, 59);
		soulPosition.y = Random.Range(-28, 28);

		print (soulPosition + " " + playerPosition);
		soulSprite.transform.position = soulPosition;
		soulSprite.enabled = true;
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}