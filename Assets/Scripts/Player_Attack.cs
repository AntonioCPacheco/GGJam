using UnityEngine;
using System.Collections;

public class Player_Attack : MonoBehaviour
{
    public Sprite handle;
    InputManager input;
    GameObject toDrag;
    GameObject trail;
    float speed = 0.5f;
    bool dragging = false;
    float radius = 2;
    void Start()
    {
        input = GetComponent<InputManager>();
    }

    void Update()
    {
        Vector3 mousePosition = input.Right_Mouse_Click();
        if (mousePosition != new Vector3(-1, -1, -1))
        {
            if (!dragging)
            {
                var layermask = (1 << LayerMask.NameToLayer("Movable"));
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero, layermask);
                
                if (hit.collider != null && hit.collider.gameObject.tag == "Movable" && (hit.point - (Vector2)transform.position).sqrMagnitude <= (radius*radius))
                {

                    if(hit.transform.gameObject.tag == "Movable")
                    {
                        toDrag = hit.transform.parent.gameObject;
                    } else
                    {
                        toDrag = hit.transform.gameObject;
                    }
                    trail = new GameObject();
                    trail.transform.position = transform.position;
                    SpriteRenderer sr = trail.AddComponent<SpriteRenderer>();
                    sr.sprite = handle;
                    float angle = Vector2.Angle(Vector2.right, toDrag.transform.position - transform.position);
                    if (toDrag.transform.position.y < transform.position.y)
                    {
                        angle = 360 - angle;
                    }
                    trail.transform.Rotate(new Vector3(0,0,angle));
                    dragging = true;
                    Cursor.visible = false;
                    Debug.Log("Target Position: " + toDrag.transform.position);
                }
            }
            if (dragging && toDrag != null)
            {
                trail.transform.position = transform.position;
                float angle = Vector2.Angle(Vector2.right, toDrag.transform.position - transform.position);
                if (toDrag.transform.position.y < transform.position.y)
                {
                    angle = 360 - angle;
                }
                trail.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                mousePosition.z = toDrag.transform.position.z;
                toDrag.transform.position = Vector3.Lerp(toDrag.transform.position, mousePosition, speed * Time.deltaTime);
            }
        } else if(dragging)
        {
            GameObject.Destroy(trail);
            Cursor.visible = true;
            dragging = false;
            toDrag = null;
        }
    }


    /*
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
    }*/
}