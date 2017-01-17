using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerPhysics : MonoBehaviour {

    /*private BoxCollider2D collider;
    private Vector3 s;
    private Vector3 c;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        s = collider.size;
    }

	// Use this for initialization
	public void Move(Vector2 moveAmount)
    {
        float deltaX = moveAmount.x;
        float deltaY = moveAmount.y;
        Vector2 p = transform.position;

        Vector2 finalTransform = new Vector2(deltaX, deltaY);
        transform.Translate(moveAmount);
    }*/
}
