using UnityEngine;
using System.Collections;

public class Wave_Behaviour : MonoBehaviour {

    public float minScale = 1;
    public float maxScale = 4;
    public int timeToSpread = 3;
    float ratioOfIncrease = 0;
    float timeOfCreation = 0;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(minScale, minScale, 1);
        timeOfCreation = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.localScale.x >= maxScale)
        {
            GameObject.Destroy(this.gameObject);
        } else
        {
            float ratio = ((maxScale - minScale) * (Time.realtimeSinceStartup - timeOfCreation) / timeToSpread);
            transform.localScale = new Vector3(transform.localScale.x + ratio, transform.localScale.y + ratio, 1);
        }
	}
}
