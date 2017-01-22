using UnityEngine;
using System.Collections;

public class Wave_Animation : MonoBehaviour {

    public float timeToFade = .2f;

    float timeInstantiated;

    void Start ()
    {
        timeInstantiated = Time.realtimeSinceStartup;
    }

    void Update ()
    {
        if (Time.realtimeSinceStartup - timeInstantiated > timeToFade)
        {
            Destroy(this.gameObject);
        }

    }

}
