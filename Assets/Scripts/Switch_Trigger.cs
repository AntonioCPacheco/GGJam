using UnityEngine;
using System.Collections;

public class Switch_Trigger: InteractableObject {

    public GameObject door;

    void Start()
    {
        
    }

    public override void trigger(RaycastHit2D col, Vector2 origin, float radius)
    {
        door.GetComponent<Door_Switch_Behaviour>().animationStart = true;

    }
}
