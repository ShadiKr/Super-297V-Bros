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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (type == CollectableType.POINTS)
            {
                collision.GetComponent<PlayerManager>().PointsCollected++;
            }
            else
            {
                collision.GetComponent<PlayerManager>().health += 20f;
            }
            GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject,1f);
        }
    }
}
