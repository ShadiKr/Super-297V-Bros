using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If you touch the ground, reset jumps and fsm
        if (collision.tag == "Ground")
        {
            GetComponentInParent<PlayerMovement>().jumpCount = GetComponentInParent<PlayerMovement>().maxJumps;
            GetComponentInParent<Animator>().SetBool("Jump", false);
            GetComponentInParent<PlayerMovement>().inHitstun = false;
        }
        
        //If you stomp an enemy, kill the enemy
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        //If collided with the blast zone, end the game and show the score
        if (collision.tag == "BlastZone")
        {
            GameObject.Find("GameOver").GetComponent<GameOverScreen>().Setup(GetComponentInParent<PlayerManager>().PointsCollected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If you leave the ground
        if (collision.tag == "Ground")
        {
            GetComponentInParent<Animator>().SetBool("Jump", true);
        }
    }
}
