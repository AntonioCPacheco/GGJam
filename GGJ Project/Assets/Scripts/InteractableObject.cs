using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public abstract void trigger(RaycastHit2D col, Vector2 origin, float radius);
}
