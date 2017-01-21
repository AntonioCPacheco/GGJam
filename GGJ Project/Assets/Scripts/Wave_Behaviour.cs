using UnityEngine;
using System.Collections;

public class Wave_Behaviour : MonoBehaviour {

    public Vector2 direction;
    public int mode = 0; //0 - omnidirectional | 1 - directional
    public float radius = 1.5f;
    float currentRadius = 0;

	// Use this for initialization
	void Start () {
        if(mode == 1)
            direction.Normalize();
    }
	
	// Update is called once per frame
	void Update () {
        currentRadius += 0.1f;
        switch (mode)
        {
            case (0):
                for(int i = 0; i < 64; i++)
                {
                    Vector2 endpoint = new Vector2(Mathf.Cos((2*Mathf.PI / 64)*i), Mathf.Sin((2 * Mathf.PI / 64) * i));
                    RaycastHit2D rayhit = Physics2D.Linecast(transform.position, currentRadius * endpoint.normalized, LayerMask.NameToLayer("WaveCollision"));
                    if(rayhit)
                    {
                        Debug.Log("HIT SOMEHTING! It's name is: " + rayhit.collider.gameObject.name);
                        //FIXME
                        //rayhit.collider.gameObject.GetComponent<>().trigger(transform.position, rayhit);
                    }
                }
                break;
            case (1):
                for(int i = 0; i < 8; i++)
                {
                    Vector2 endpoint = new Vector2(Mathf.Cos((2 * Mathf.PI / 64) * i), Mathf.Sin((2 * Mathf.PI / 64) * i));
                    RaycastHit2D rayhit = Physics2D.Linecast(transform.position, currentRadius * endpoint.normalized, LayerMask.NameToLayer("WaveCollision"));
                    if (rayhit)
                    {
                        Debug.Log("HIT SOMEHTING! It's name is: " + rayhit.collider.gameObject.name);
                        //FIXME
                        //rayhit.collider.gameObject.GetComponent<>().trigger(transform.position, rayhit);
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
