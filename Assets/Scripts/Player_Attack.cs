using UnityEngine;
using System.Collections;

public class Player_Attack : MonoBehaviour
{

    public float maxRadius = .5f;
    public float castSpeed = .01f;
    public float dragFriction = 50.0f;
    public float deltaThreshold = 1f;

    private Vector2 direction;
    private float currentRadius = 0.0f;
    private float playerRadius = .2f;
    private RaycastHit2D rayhit;

    private Vector3 delta = Vector3.zero;
    private Vector3 lastPos = Vector3.zero;

    InputManager input;

    void Start()
    {

        direction = new Vector2(.0f, 1.0f);
        input = GetComponent<InputManager>();
        playerRadius = GetComponent<CircleCollider2D>().radius;

    }

    void Update()
    {

        Vector3 mouseDownPosition = input.Right_Mouse_Click_Down();
        Vector3 mouseInput = input.Right_Mouse_Click();

        if (!mouseDownPosition.Equals(new Vector3(-1.0f, -1.0f, -1.0f)))
        {
            lastPos = mouseDownPosition;
        }

        if (!mouseInput.Equals(new Vector3(-1.0f, -1.0f, -1.0f)))
        {
            delta = mouseInput - lastPos;

            mouseInput = Camera.main.ScreenToWorldPoint(mouseInput);

            var layermask = (1 << LayerMask.NameToLayer("Movable") | 1 << LayerMask.NameToLayer("WaveCollision"));
            rayhit = Physics2D.Linecast(transform.position, mouseInput, layermask);
            //if (rayhit.collider == null)
            //    currentRadius = Mathf.Clamp(currentRadius + castSpeed, 0.0f, maxRadius);

            Debug.DrawLine(transform.position, mouseInput, Color.red);
            if (rayhit.collider != null && rayhit.collider.tag == "Pickable")
            {
                rayhit.rigidbody.velocity = Vector2.zero;

                rayhit.transform.position = new Vector3(mouseInput.x, mouseInput.y, 0.0f); //new Vector3(this.transform.position.x + currentRadius, this.transform.position.y + currentRadius);
                if (!mouseInput.Equals(delta))
                    rayhit.rigidbody.velocity = new Vector2(delta.x / dragFriction, delta.y / dragFriction);
            }
            lastPos = Input.mousePosition;
        }
        else
        {
            currentRadius = 0.0f;
        }
    }
}