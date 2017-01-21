using UnityEngine;
using System;

public class RepeaterObject : InteractableObject
{
    public CircleCollider2D circle;

    void Start()
    {
        circle = this.gameObject.GetComponent<CircleCollider2D>();
    }

    public override void trigger(RaycastHit2D col, Vector2 origin, float radius)
    {
        float aux_vec_x = col.point.x;
        float aux_vec_y = col.point.y;
        Vector2 aux_vec = new Vector2(aux_vec_x, aux_vec_y);
        Vector2 new_origin = aux_vec.normalized * circle.radius + (Vector2)transform.position;
        Debug.Log(new_origin);
        Physics2D.Linecast(new_origin, (new_origin + aux_vec.normalized)*radius);
        Debug.DrawLine(new_origin, (new_origin + aux_vec.normalized) * radius, Color.white);
        /*
        Vector2 center = circle.transform.position;
        float xx = 

        Vector2 aux_vec = circle.offset - col.point;
        Vector2 new_origin = (Vector2)circle.transform.position - aux_vec;
        Debug.Log(circle.transform.position);
        Physics2D.Linecast(new_origin, ((origin - col.point).normalized));
        Debug.DrawLine(new_origin, ((origin - col.point).normalized), Color.white);
        */
    }
}
