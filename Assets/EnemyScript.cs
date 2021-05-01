using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum meanieState
{
    idling,
    chasing,
    attacking,
}
public class EnemyScript : Attackable
{
    public bool airBound;
    private GameObject Player;
    private Rigidbody2D body;
    private ParticleSystem deathEffect;
    private bool counting = false;
    public meanieState currentState;
    public float lineOfSight = 15;
    public float speed = 42;
    // Start is called before the first frame update


    void Start()
    {
        currentState = meanieState.idling;
        body = GetComponent<Rigidbody2D>();
        deathEffect = GetComponent<ParticleSystem>();
        Player = GameObject.Find("Pinky");
    }

    // Update is called once per frame
    private void Update()
    {
        if (isHit)
        {
            SceneManager.LoadScene("Turn-Based Fight");
        }
        switch (currentState)
        {
            case meanieState.idling:
                Idle();
                break;

            case meanieState.chasing:
                if (!airBound)
                {
                    Chase();
                }
                break;
        }
        if (HP <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (!counting)
            {
                counting = true;
                deathEffect.Play();
            }
            Kill(false);
        }
    }

    public void Idle()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < lineOfSight)
        {
            currentState = meanieState.chasing;
        }
    }

    public void Chase()
    {
        Vector3 moveTowards = Player.transform.position - transform.position;
        moveTowards.Normalize();
        float dampening = 10;
        body.velocity = new Vector2(moveTowards.x / dampening * speed, body.velocity.y);
        if (Mathf.Sign(moveTowards.x) != 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(moveTowards.x), transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(1f, transform.localScale.y);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
