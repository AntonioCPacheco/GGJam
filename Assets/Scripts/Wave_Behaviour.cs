using UnityEngine;
using System.Collections;

public class Wave_Behaviour : MonoBehaviour {

    public Vector2 direction;
    public int mode = 1; //0 - omnidirectional | 1 - directional
    public float radius = 1.5f;
    public float timeToExpand = 3;
    float currentRadius = 0;

    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.realtimeSinceStartup;
        //if(mode == 1)
        //    direction.Normalize();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, direction);
        if(Time.realtimeSinceStartup - startTime > timeToExpand)
        {
            GameObject.Destroy(this.gameObject);
        }
        currentRadius = radius * ((Time.realtimeSinceStartup - startTime)/timeToExpand);
        switch (mode)
        {
            case (0):
                for(int i = 0; i < 64; i++)
                {
                    Vector2 endpoint = new Vector2(Mathf.Cos((2*Mathf.PI / 64) * i), -Mathf.Sin((2*Mathf.PI / 64) * i));
                    var layermask = (1 << LayerMask.NameToLayer("WaveCollision"));
                    RaycastHit2D rayhit = Physics2D.Linecast(transform.position, currentRadius * endpoint.normalized, layermask);
                    Debug.DrawLine(transform.position, currentRadius * endpoint.normalized, Color.black);
                    if (rayhit.collider != null)
                    {
                        Debug.Log("HIT SOMETHING! It's name is: " + rayhit.collider.gameObject.name);
                        //FIXME
                        //rayhit.collider.gameObject.GetComponent<>().trigger(transform.position, rayhit);
                    }
                }
                break;
            case (1):
                
                float angle = Vector2.Angle(Vector2.right, direction);
                Debug.Log(angle);
                if (direction.y < transform.position.y && direction.x < transform.position.x)
                {
                    angle += 180;
                }
                for (int i = 0; i <= 8; i++)
                {
                    Vector2 endpoint = new Vector2(Mathf.Cos((2 * Mathf.PI / 64) * i), Mathf.Sin((2 * Mathf.PI / 64) * i));
                    
                    endpoint = Quaternion.AngleAxis(-22.5f, Vector3.forward) * endpoint;
                    endpoint = Quaternion.AngleAxis(angle, Vector3.forward) * endpoint;
                    endpoint += new Vector2(transform.position.x, transform.position.y);
                    var layermask = (1 << LayerMask.NameToLayer("WaveCollision"));
                    //Vector2 scaledDirection = Vector2.Scale(endpoint - (Vector2)transform.position, new Vector2(currentRadius, currentRadius));
                    //endpoint = scaledDirection + (Vector2)transform.position;
                    RaycastHit2D rayhit = Physics2D.Linecast(transform.position, endpoint, layermask);
                    Debug.DrawLine(transform.position, endpoint, Color.black);
                    if (rayhit)
                    {
                        //Debug.Log("HIT SOMEHTING! It's name is: " + rayhit.collider.gameObject.name);
                        rayhit.collider.gameObject.GetComponent<InteractableObject>().trigger(rayhit, transform.position, currentRadius);
                    }
                }
                break;
        }
        
        
        /*
        if(transform.localScale.x >= maxScale)
        {
            GameObject.Destroy(this.gameObject);
        } else
        {
            float ratio = ((maxScale - minScale) * (Time.realtimeSinceStartup - timeOfCreation) / timeToSpread);
            transform.localScale = new Vector3(transform.localScale.x + ratio, transform.localScale.y + ratio, 1);
        }*/
	}
}
