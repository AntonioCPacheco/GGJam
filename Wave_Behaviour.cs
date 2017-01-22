using UnityEngine;
using System.Collections;

public class Wave_Behaviour : MonoBehaviour {

    public GameObject waveSprite;
    public Vector2 direction;
    public int mode = 1; //0 - omnidirectional | 1 - directional | 2 - unidirectional
    public float radius = 10f;
    public float timeToExpand = 10;
    public float timeBetweenWaves = .3f;

    bool[] collided;

    float currentRadius = 0;

    float startTime;
    float timeOfLastWave;

	// Use this for initialization
	void Start () {
        collided = new bool[9];
        for(int i = 0; i<9; i++)
        {
            collided[i] = false;
        }
        startTime = Time.realtimeSinceStartup;
        timeOfLastWave = startTime;

        if(mode == 2)
        {
            transform.position += (Vector3)Vector2.Scale(direction.normalized, new Vector2(0.01f, 0.01f));
        }
    }
	
	// Update is called once per frame
	void Update () {
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
                        rayhit.collider.gameObject.GetComponent<InteractableObject>().trigger(rayhit, transform.position, currentRadius);
                    }
                }
                break;
            case (1):
                
                float angle = Vector2.Angle(Vector2.right, direction-(Vector2)transform.position);
                if (direction.y < transform.position.y)
                {
                    angle = 360 - angle;
                }
                for (int i = 0; i <= 8; i++)
                {
                    if (!collided[i])
                    {
                        Vector2 endpoint = new Vector2(Mathf.Cos((2 * Mathf.PI / 64) * i), Mathf.Sin((2 * Mathf.PI / 64) * i));

                        endpoint = Quaternion.AngleAxis(-22.5f, Vector3.forward) * endpoint;
                        endpoint = Quaternion.AngleAxis(angle, Vector3.forward) * endpoint;
                        endpoint += new Vector2(transform.position.x, transform.position.y);
                        var layermask = (1 << LayerMask.NameToLayer("WaveCollision"));

                        Vector2 scaledDirection = Vector2.Scale(endpoint - (Vector2)transform.position, new Vector2(currentRadius, currentRadius));
                        endpoint = scaledDirection + (Vector2)transform.position;

                        RaycastHit2D rayhit = Physics2D.Linecast(transform.position, endpoint, layermask);
                        Debug.DrawLine(transform.position, endpoint, Color.black);
                        if (rayhit)
                        {
                            collided[i] = true;
                            rayhit.collider.gameObject.GetComponent<InteractableObject>().trigger(rayhit, transform.position, currentRadius);
                        }
                    }
                }
                break;
            case (2):
                //FIXME
                timeToExpand = radius * 0.4f;
                var layermask = (1 << LayerMask.NameToLayer("WaveCollision"));
                
                Vector2 scaledDirection = Vector2.Scale(direction.normalized, new Vector2(currentRadius, currentRadius));
                direction = scaledDirection;
                
                RaycastHit2D rayhit = Physics2D.Linecast(transform.position, direction + (Vector2)transform.position, layermask);
                Debug.DrawLine(transform.position, direction + (Vector2)transform.position, Color.magenta);
                if (Time.realtimeSinceStartup - timeOfLastWave >= timeBetweenWaves)
                {
                    GameObject waveSpr = (GameObject)Instantiate(waveSprite, transform);
                    //GameObject waveSpr = (GameObject)Instantiate(waveSprite, this.transform.position, Quaternion.LookRotation(-Vector3.forward, (Vector3)direction - this.transform.position));
                    waveSpr.transform.position = (Vector2)this.transform.position + direction;
                    Vector3 from = new Vector3(-1,1,0);
                    Vector3 from_vec = (from - this.gameObject.transform.position).normalized;
                    Vector3 to_vec = (new Vector3(direction.x, direction.y, .0f)).normalized;
                    waveSpr.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), Vector3.Angle(from_vec, to_vec));
                    timeOfLastWave = Time.realtimeSinceStartup;
                }
                if (rayhit)
                {
                    Debug.Log("HIT SOMETHING! It's name is: " + rayhit.collider.gameObject.name);
                    GameObject.Destroy(this.gameObject);
                    rayhit.collider.gameObject.GetComponent<InteractableObject>().trigger(rayhit, transform.position, currentRadius);
                }
                break;
            default:
                break;
        }
	}
}
