using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed = .0f;
    public float acceleration = .03f;
    public float friction = .01f;
    public float maxSpeed = .5f;

    InputManager input;
    Rigidbody2D rigidBody;

    Vector2 vel;

    void Start()
    {
        input = GetComponent<InputManager>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");
        if (Mathf.Abs(h) > 0.0f || Mathf.Abs(v) > 0.0f)
        {
            moveSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            moveSpeed -= friction * Time.deltaTime;
        }
        moveSpeed = Mathf.Clamp(moveSpeed, 0.0f, maxSpeed);
        Move (h, v);

    }

    void Move(float h, float v)
    {
        //vel.Set(h, v);
        vel += new Vector2(h, v);

        vel = vel.normalized * moveSpeed * Time.deltaTime;

        rigidBody.MovePosition((Vector2)transform.position + vel);

    }

    void Update()
    {
        //moveSpeed -= (dampTime * Time.deltaTime);
        //rigidBody.velocity = vel.normalized * moveSpeed;
    }
}
