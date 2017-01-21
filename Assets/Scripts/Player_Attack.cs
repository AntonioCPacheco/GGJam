using UnityEngine;
using System.Collections;

public class Player_Attack : MonoBehaviour {

    public float maxRadius = .5f;
    public float castSpeed = .01f;

    private Vector2 direction;
    private float currentRadius = 0.0f;
    private float playerRadius = .2f;
    private RaycastHit2D rayhit;
    float xOffset, yOffset;

    private Vector3 delta = Vector3.zero;
    private Vector3 lastPos = Vector3.zero;

    InputManager input;

	void Start () {

        direction = new Vector2(.0f, 1.0f);
        input = GetComponent<InputManager>();
        playerRadius = GetComponent<CircleCollider2D>().radius;

        xOffset = playerRadius;
        yOffset = playerRadius;
	}
	
	void Update () {
        Vector3 mouseDownPosition = input.Right_Mouse_Click_Down();
        Vector3 mouseInput = input.Right_Mouse_Click();

        if (!mouseDownPosition.Equals(new Vector3(-1.0f, -1.0f, -1.0f)))
        {
            lastPos = mouseDownPosition;
        }
 
        if (!mouseInput.Equals(new Vector3(-1.0f, -1.0f, -1.0f)))
        {
            delta = mouseInput - lastPos;

            Debug.Log( "delta X : " + delta.x );
            Debug.Log( "delta Y : " + delta.y );
            Debug.Log( "delta distance : " + delta.magnitude );

            mouseInput = Camera.main.ScreenToWorldPoint(mouseInput);

            var layermask = (1 << LayerMask.NameToLayer("Movable"));
            rayhit = Physics2D.Linecast(transform.position, mouseInput, layermask);
            //if (rayhit.collider == null)
            //    currentRadius = Mathf.Clamp(currentRadius + castSpeed, 0.0f, maxRadius);

            Debug.DrawLine(transform.position, mouseInput, Color.red);
            if (rayhit.collider != null)
            {
                //Debug.Log("Hit something movable");
                //Vector3 collidedPos = collided.transform.position;
                rayhit.transform.position = new Vector3(mouseInput.x, mouseInput.y, 0.0f); //new Vector3(this.transform.position.x + currentRadius, this.transform.position.y + currentRadius);
            }
        }
        else
        {
            currentRadius = 0.0f;
        }
	}
}
