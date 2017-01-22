using UnityEngine;
using System.Collections;

public class ReppelAreaEffector : MonoBehaviour {

    AreaEffector2D effector;
    GameObject player;

	// Use this for initialization
	void Start () {
        effector = GetComponent<AreaEffector2D>();
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float angle = Vector2.Angle(Vector2.right, player.transform.position - transform.position);
        if (player.transform.position.y < transform.position.y)
        {
            angle = 360 - angle;
        }
        effector.forceAngle = angle;
    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float angle = Vector2.Angle(Vector2.right, other.transform.position - transform.position);
            if (other.transform.position.y < transform.position.y)
            {
                angle = 360 - angle;
            }
            effector.forceAngle = angle;
        }
    }*/
}
