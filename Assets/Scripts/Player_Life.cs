using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player_Life : MonoBehaviour {

    public bool canDie = true;

    public int life = 4;

    public Sprite[] blobSprites = new Sprite[4];

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void ComputePlayerHealth()
    {
        if (canDie)
        {
            if (life > 1)
            {
                life -= 1;
                GetComponent<SpriteRenderer>().sprite = blobSprites[life - 1];
            }
            else
            {
                SceneManager.LoadScene("Main 1");
            }
        }
    }
}
