using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GeneratorScript5 : MonoBehaviour
{

    public GameObject[] availableRooms;
    public List<GameObject> currentRooms;
    public GameObject lastRoom;
    //public SpriteRenderer soulSprite;
    private float screenWidthInPoints;
    private static float roomCount = 0;
   // public Image content;
   // public CameraFollow cameraScript;

    // Use this for initialization
    void Start()
    {
        //gameObject.GetComponent<Renderer> ().enabled = false;
        //cameraScript = GetComponent<CameraFollow>();
        //soulSprite.enabled = false;
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
        //HandleBar(stars);
    }

    //Add Last Room
    void AddLastRoom(float farhtestRoomEndX)
    {
        //int randomRoomIndex = Random.Range(0, availableRooms.Length);
        GameObject room = (GameObject)Instantiate(lastRoom);
        float roomWidth = screenWidthInPoints;
        float roomCenter = farhtestRoomEndX;
        room.transform.position = new Vector3(roomCenter, 0, 0);
        currentRooms.Add(room);
    }

    //Generate room if required
    void GenerateLastRoom()
    {
        //List<GameObject> roomsToRemove = new List<GameObject>();
        bool addRooms = true;
        float playerX = transform.position.x;
        float removeRoomX = playerX - screenWidthInPoints;
        float addRoomX = playerX + screenWidthInPoints;
        //float farthestRoomEndX = 0;


        //		float roomWidth = lastRoom.transform.FindChild("floor").localScale.x;
        //		float roomStartX = lastRoom.transform.position.x - (roomWidth * 0.5f);    
        //		float roomEndX = addRoomX + roomWidth;

        float roomWidth = screenWidthInPoints;
        float roomStartX = lastRoom.transform.position.x - (roomWidth);
        float roomEndX = roomStartX + screenWidthInPoints;

        /*if (roomStartX > addRoomX)
				addRooms = false;

			if (roomEndX < removeRoomX)
			{
				//roomsToRemove.Add(room);
				addRooms = true;
			}*/

        //farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);




        //if (addRooms) {
        AddLastRoom(Variables5.lastRoomStartX);
        Variables5.isLastScene = false;
        //}
    }

    void FixedUpdate()
    {
        //GenerateRoomIfRequired();
        if (!Variables5.doLoadLastScene)
            GenerateRoomIfRequired();
        else if (Variables5.isLastScene)
        {
            GenerateLastRoom();
        }
    }

    void AddRoom(float farhtestRoomEndX)
    {
        int randomRoomIndex = Random.Range(0, availableRooms.Length);
        GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);
        float roomWidth = screenWidthInPoints;
        float roomCenter = farhtestRoomEndX + roomWidth;
        room.transform.position = new Vector3(roomCenter, 0, 0);
        currentRooms.Add(room);
    }

    void GenerateRoomIfRequired()
    {
        List<GameObject> roomsToRemove = new List<GameObject>();
        bool addRooms = true;
        float playerX = transform.position.x;
        float removeRoomX = playerX - screenWidthInPoints;
        float addRoomX = playerX + screenWidthInPoints;
        float farthestRoomEndX = 0;

        foreach (var room in currentRooms)
        {
            float roomWidth = screenWidthInPoints;
            float roomStartX = room.transform.position.x - (roomWidth);
            float roomEndX = roomStartX + screenWidthInPoints;

            if (roomStartX > addRoomX)
            {
                addRooms = false;
            }
            if (roomEndX < removeRoomX)
                roomsToRemove.Add(room);

            farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
        }

        foreach (var room in roomsToRemove)
        {
            currentRooms.Remove(room);
            Destroy(room);
        }

        if (addRooms)
        {
            print("Farthest Room X is " + farthestRoomEndX);
            if (roomCount < 5)
            {
                AddRoom(farthestRoomEndX);
                roomCount++;
            }
            else
            {
                Variables5.doLoadLastScene = true;
                Variables5.lastRoomStartX = farthestRoomEndX + screenWidthInPoints;
            }
        }
    }

    /*void CollectStars(Collider2D starCollider)
    {
        stars++;
        Destroy(starCollider.gameObject);
        HandleBar(stars);
    }

    void HitByObject()
    {
        stars = stars - 5;
        HandleBar(stars);
    }*/

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("stars"))
        {//CollectStars(collider);
        }
        else if (collider.gameObject.CompareTag("soul"))
        {

        }
        
            //HitByObject();
    }

    public void HandleBar(float Value)
    {
        /*float progress = Map(Value, 0, 10, 0, 1);
        print(progress);
        if (progress < 1.1)
        {
            content.fillAmount = progress;
        }
        else
        {
            print("finished");
            //Time.timeScale = 0;
            //GameObject.Find("Main Camera").GetComponent(CameraFollow).enabled = false;
            //cameraScript.enabled = false;
           // CameraFollow.Move = false;
            //soulSprite.enabled = true;
        }*/
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}