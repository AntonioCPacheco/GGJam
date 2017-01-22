using UnityEngine;
using System.Collections;

public class Energy_Fountain : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player_Life>().life = 4;
            col.gameObject.GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<Player_Life>().blobSprites[col.gameObject.GetComponent<Player_Life>().life - 1];
        }
        this.gameObject.SetActive(false);
    }
}
