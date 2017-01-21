using UnityEngine;
using System;

public class ReflectionObject : InteractableObject
{
    public EdgeCollider2D self_collider;
    public Vector2 collider_orientation;

    public ReflectionObject()
    {
        Vector2 pos1 = self_collider.points[0];
        Vector2 pos2 = self_collider.points[self_collider.points.Length - 1];

        collider_orientation = pos2 - pos1;
    }

    public void OnCollisionEnter2D(Collision col)
    {

    }

    public void Collided(RaycastHit2D ray, Vector2 origin)
    {
        Vector2 point_of_collision = ray.point;
        Vector2 hit_vector = point_of_collision - origin;

        //Physics2D.Linecast(point_of_collision, );
    }

}
