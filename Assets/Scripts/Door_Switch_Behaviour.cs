using UnityEngine;
using System.Collections;

public class Door_Switch_Behaviour : MonoBehaviour {

    public Vector3 doorFinalPos;
    public bool animationStart = false;

    Vector3 doorInitialPos;
    float transitionStatus = .0f;
    float transitionDuration = 2.0f;

	void Start () {
        doorInitialPos = transform.position;
	}
	
	void Update () {
        if (animationStart == true)
        {
            if (transitionStatus < 1.0f)
            {
                transitionStatus += (1.0f / transitionDuration) * Time.deltaTime;
                transform.position = Vector3.Lerp(doorInitialPos, doorFinalPos, transitionStatus);
            }
        }
	
	}
}
