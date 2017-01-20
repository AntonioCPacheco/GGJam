using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public bool up;
    public bool down;
    public bool right;
    public bool left;
    public bool mouse_click;
    public Vector3 mouse_position;

    public bool Left()
    {
        return Input.GetKeyDown("w") || Input.GetKeyDown("W");
    }

    public bool Right()
    {
        return Input.GetKeyDown("w") || Input.GetKeyDown("W");
    }

    public bool Up()
    {
        return Input.GetKeyDown("w") || Input.GetKeyDown("W");
    }

    public bool Down()
    {
        return Input.GetKeyDown("w") || Input.GetKeyDown("W");
    }

    public Vector3 Mouse_Click()
    {
        if(Input.GetMouseButtonDown(0))
        {
            return Input.mousePosition;
        }
        else
        {
            return new Vector3(-1, -1, -1);
        }
    }
}
