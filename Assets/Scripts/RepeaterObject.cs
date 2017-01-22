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
        //Debug.DrawLine(Vector2.zero, dir, Color.magenta);
        hits.Add(dir.normalized);

        Wave_Behaviour wave = Instantiate(wavePrefab).GetComponent<Wave_Behaviour>();
        wave.mode = 2;
        wave.gameObject.transform.position = col.point;
        wave.direction = dir;
        wave.radius = 10;
    }
}
