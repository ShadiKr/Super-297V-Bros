using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitShoot : MonoBehaviour
{
    public float speed = 32f;
    private Vector3 shootDir;
    private BoxCollider2D collider2D;
    private SpriteRenderer SpriteRenderer;

    //Setup the shot
    public void Setup(Vector3 shootDir)
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider2D = gameObject.GetComponent<BoxCollider2D>();
        this.shootDir = shootDir;
        SpriteRenderer.transform.localScale = new Vector3(Mathf.Sign(shootDir.x), 1, 1);
        StartCoroutine(Fade());
    }

    //Move the projectile along the x-axis
    public void Update()
    {
        transform.position += shootDir * Time.deltaTime * speed;
    }

    //Disable the renderer and collider after a certain amount of time (this determines the range)
    IEnumerator Fade()
    {
        SpriteRenderer.enabled = true;
        collider2D.enabled = true;
        yield return new WaitForSeconds(.35f);
        collider2D.enabled = false;
        SpriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }    
    }
}
