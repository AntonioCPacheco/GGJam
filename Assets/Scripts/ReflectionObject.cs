using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReflectionObject : InteractableObject
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

        foreach (Vector2 direction in hits)
        {
            if (direction.Equals((col.point - origin).normalized))
            {
                return;
            }
        }

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
        //Vector2 scaledDirection = Vector2.Scale(outgoing, new Vector2((1 - col.fraction) * radius, (1 - col.fraction) * radius));
        //outgoing = scaledDirection + col.point;

        Physics2D.Linecast(col.point, outgoing + col.point);
        Debug.DrawLine(col.point, outgoing + col.point, Color.magenta);
        hits.Add(dir.normalized);

        Wave_Behaviour wave = Instantiate(wavePrefab).GetComponent<Wave_Behaviour>();
        wave.mode = 2;
        wave.gameObject.transform.position = col.point;
        wave.direction = outgoing;
        wave.radius = 10;

        /*
        Debug.DrawLine(col.point, col.normal * 10, Color.red);
        Vector2 incident = col.point - origin;

        float angle = Vector2.Angle(col.normal, incident); //Esta funcao devolve sempre um angulo entre 0 e 180

        Vector3 cross = Vector3.Cross(col.normal, incident);
        if (cross.z > 0)
        {
            angle = 2*(180 - angle);
        } else if(angle > 90)
        {
            angle = -2*(180 - angle);
        }

        //Debug.Log(angle);
        Vector2 outgoing = Quaternion.AngleAxis(angle, Vector3.forward) * ((origin - col.point).normalized);
        Vector2 scaledDirection = Vector2.Scale(outgoing-origin, new Vector2((1-col.fraction)*radius, (1 - col.fraction) * radius));
        outgoing = scaledDirection + col.point;

        Physics2D.Linecast(col.point, outgoing);
        //Debug.DrawLine(col.point, outgoing, Color.white);*/
    }
}
