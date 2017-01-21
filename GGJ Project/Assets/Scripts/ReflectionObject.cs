using UnityEngine;
using System;

public class ReflectionObject : InteractableObject
{
    public override void trigger(RaycastHit2D col, Vector2 origin, float radius)
    {
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
        Debug.DrawLine(col.point, outgoing, Color.white);
    }
}
