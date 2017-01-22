using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReflectionObject : InteractableObject
{
    List<Vector2> hits;
    public float setRadius = 10;
    //float radius;
    public GameObject wavePrefab;

    void Start()
    {
        hits = new List<Vector2>();
    }

    public override void trigger(RaycastHit2D col, Vector2 origin, float radius)
    {
        Vector2 dir = origin - col.point;
        float angle = Vector2.Angle(col.normal, dir);
        Vector3 cross = Vector3.Cross(col.normal, dir);
        if (cross.z > 0)
        {
            angle = 360 - angle;
            angle *= 2;
        }
        else
        {
            angle = 360 - angle;
            angle *= -2;
        }
        Debug.Log(angle);
        Vector2 outgoing = Quaternion.AngleAxis(angle, Vector3.forward) * dir;
        foreach (Vector2 direction in hits)
        {
            if (direction.Equals(outgoing.normalized))
            {
                return;
            }
        }
        hits.Add(outgoing.normalized);

        Physics2D.Linecast(col.point, outgoing + col.point);
        Debug.DrawLine(col.point, outgoing + col.point, Color.magenta);

        Wave_Behaviour wave = Instantiate(wavePrefab).GetComponent<Wave_Behaviour>();
        wave.mode = 2;
        wave.gameObject.transform.position = col.point;
        wave.direction = outgoing;
        wave.radius = setRadius;
        wave.timeToExpand = setRadius*0.4f;
        
    }
}
