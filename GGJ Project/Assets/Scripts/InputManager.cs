using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool Left()
    {
        return Input.GetKey(KeyCode.A);
    }

    public bool Right()
    {
        return Input.GetKey(KeyCode.D);
    }

    public bool Up()
    {
        return Input.GetKey(KeyCode.W);
    }

    public bool Down()
    {
        return Input.GetKey(KeyCode.S);
    }

    public Vector3 Left_Mouse_Click()
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

    public Vector3 Right_Mouse_Click()
    {
        if (Input.GetMouseButtonDown(1))
        {
            return Input.mousePosition;
        }
        else
        {
            return new Vector3(-1, -1, -1);
        }
    }
}
