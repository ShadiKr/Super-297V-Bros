using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    public bool isHit = false;
    public float HP = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Kill(true);
        }
    }
    public bool getHit()
    {
        return isHit;
    }

    public void setHit(bool condition)
    {
        isHit = condition;
    }


    /// <summary>
    /// Use inheritance later on for enemies, buttons, and the such
    /// </summary>
    /// 
    public virtual void Kill(bool overrideKB)
    {
        if (overrideKB)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 1f)*8, ForceMode2D.Impulse);
        }
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 0.25f);
    }
}
