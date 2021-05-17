using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            GetComponentInParent<PlayerMovement>().jumpCount = GetComponentInParent<PlayerMovement>().maxJumps;
            GetComponentInParent<Animator>().SetBool("Jump", false);
            GetComponentInParent<PlayerMovement>().inHitstun = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            GetComponentInParent<Animator>().SetBool("Jump", true);
        }
    }
}
