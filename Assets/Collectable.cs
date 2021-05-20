using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CollectableType
{
    POINTS,
    HEALTH,
}

public class Collectable : MonoBehaviour
{

    public CollectableType type;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Do stuff when a player collides
        if (collision.tag == "Player")
        {
            //Increase points if the collectable is a coin type
            if (type == CollectableType.POINTS)
            {
                collision.GetComponent<PlayerManager>().PointsCollected++;
            }
            //Increase health if the collectable is a health type
            else
            {
                collision.GetComponent<PlayerManager>().health += 20f;
            }
            //Play audio effect then delete the object (while disabling the main components)
            GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject,1f);
        }
    }
}
