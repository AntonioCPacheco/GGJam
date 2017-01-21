using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RepeaterObject : InteractableObject
{
    List<Vector2> hits;
    float radius;
    public GameObject wavePrefab;

    void Start()
    {
        hits = new List<Vector2>();
    }

    public override void trigger(RaycastHit2D col, Vector2 origin, float radius)
    {
        foreach(Vector2 direction in hits)
        {
            if (direction.Equals((col.point-origin).normalized))
            {
                return;
            }
        }

        Vector2 dir = col.point - origin;
        Debug.DrawLine(Vector2.zero, dir, Color.magenta);
        hits.Add(dir.normalized);

        Wave_Behaviour wave = Instantiate(wavePrefab).GetComponent<Wave_Behaviour>();
        wave.mode = 2;
        wave.gameObject.transform.position = col.point;
        wave.direction = dir;
        wave.radius = 10;

        /*
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
