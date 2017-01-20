using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed = .02f;
    public float maxSpeed = .05f;

    InputManager input;
    Rigidbody2D rigidBody;

    void Start()
    {
        input = GetComponent<InputManager>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var vel = rigidBody.velocity;
        if (input.Up()) {
            vel += new Vector2(0.0f, moveSpeed);
        }

        if (input.Down()) {
            vel += new Vector2(0.0f, -moveSpeed);
        }

        if (input.Left()) {
            vel += new Vector2(-moveSpeed, 0.0f);
        }

        if (input.Right()) {
            vel += new Vector2(moveSpeed, 0.0f);
        }

        vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        vel.y = Mathf.Clamp(vel.y, -maxSpeed, maxSpeed);

        rigidBody.velocity = vel;
    }
}
