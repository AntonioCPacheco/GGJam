using UnityEngine;
using System;

public class ReflectionObject : InteractableObject
{
    public override void trigger(RaycastHit2D col, Vector2 origin, float radius)
    {/*
        Vector2 numberOne = new Vector2(-1,-1);
        Vector2 numberTwo = new Vector2(1, 0);
        Debug.Log(Quaternion.AngleAxis(90, Vector3.forward) * numberTwo);*/
        //Debug.Log("Angle 2 - 1 : " + Vector2.Angle(numberTwo, numberOne));
        Debug.DrawLine(col.point, col.normal * 10, Color.red);
        Vector2 incident = col.point - origin;

        float angle = Vector2.Angle(col.normal, incident); //Esta funcao devolve sempre um angulo entre 0 e 180

        Vector3 cross = Vector3.Cross(col.normal, incident);
        if (cross.z > 0)
        {
            Debug.Log("hi");
            angle = 360 - angle;
            angle = 360 - angle;
            angle = 2 * (180 - angle);
        } else if(angle > 90)
        {
            angle = -2*(180 - angle);
        }

        Debug.Log(angle);
        Vector2 outgoing = Quaternion.AngleAxis(angle, Vector3.forward) * ((origin - col.point).normalized);
        //Debug.DrawLine(col.point, origin * radius, Color.green);

        Physics2D.Linecast(col.point, outgoing);
        Debug.DrawLine(col.point, outgoing, Color.white);
    }
}
