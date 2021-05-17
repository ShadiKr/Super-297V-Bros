﻿using System.Collections;
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
    public Animator enemyAnimator;
    private bool damaged;
    // Start is called before the first frame update


    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
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
                enemyAnimator.SetBool("Chase", false);
                body.velocity = new Vector2(0, body.velocity.y);
                body.angularVelocity = 0;
                Idle();
                break;

            case meanieState.chasing:
                enemyAnimator.SetBool("Chase", true);
                Chase();
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
        if (Vector3.Distance(transform.position, Player.transform.position) > lineOfSight)
        {
            currentState = meanieState.idling;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !damaged)
        {
            collision.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.collider.GetComponent<Rigidbody2D>().angularVelocity = 0;
            collision.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * 400,800));
            collision.collider.GetComponent<PlayerManager>().health -= 12;
            StartCoroutine(damageCooldown());
        }
    }

    IEnumerator damageCooldown()
    {
        damaged = true;
        yield return new WaitForSeconds(0.2f);
        damaged = false;
    }
}
