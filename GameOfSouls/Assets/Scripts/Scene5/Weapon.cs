using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour {
    public Texture2D enemyTexture;
    public GameObject enemy;
    public GameObject Reaper;
    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public int ReaperHealth = 100;
    float timeToFire = 0;
    Transform firePoint;
    int enemies = 0;
    public int enemyHealth = 100;

	// Use this for initialization
	void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
        if(firePoint == null)
        {
            Debug.LogError("No FirePoint?");
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Shoot();
	    if(fireRate == 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
               // Debug.Log("Test");
                Shoot();
            }
        }
        else
        {
            if(Input.GetButton("Fire1") && Time.time > timeToFire)
            {
               // Debug.Log("Test1");
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

        if(enemies == 150)
        {
            SceneManager.LoadScene(0);
        }
	}

    void Shoot()
    {
        Vector2 MousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
                                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, MousePosition - firePointPosition, 100, whatToHit);
      //  hit.rigidbody.name = "laser";
        if(hit.collider != null)
        {
            
            //print(hit.collider.name + " and " + enemyHealth + " object " + gameObject.name);

            if ((hit.collider.name == "enemy"))
            {
                Debug.DrawLine(firePointPosition, hit.point, Color.red);
                enemyHealth -= 25;
                if (enemyHealth <= 0)
                {

                    Destroy(enemy);
                    print("Enemy Destroyed !!");
                    enemies++;
                }

            }

            else if(hit.collider.name == "Reaper")
            {
                Debug.DrawLine(firePointPosition, hit.point, Color.red);
                ReaperHealth -= 10;
                if(ReaperHealth <=0)
                {
                    Destroy(Reaper);
                    SceneManager.LoadScene("GameOverScene");
                    enemies++;
                }

            }
            else
            {
                Debug.DrawLine(firePointPosition, (MousePosition - firePointPosition) * 100, Color.cyan);
            }
        }
        else
        {
            Debug.DrawLine(firePointPosition, (MousePosition - firePointPosition) * 100, Color.cyan);
        }
        

    }

    void DisplayCoinsCount()
    {
        Rect coinIconRect = new Rect(20, 20, 48, 48);
        GUI.DrawTexture(coinIconRect, enemyTexture);

        GUIStyle style = new GUIStyle();

        style.fontSize = 30;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.red;

        Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
        GUI.Label(labelRect, enemies.ToString(), style);
    }
    void OnGUI()
    {
        DisplayCoinsCount();
    }

}
