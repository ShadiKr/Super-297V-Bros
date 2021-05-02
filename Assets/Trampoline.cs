using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public AudioClip Jump;
    Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("IsStepped", true);
        GetComponent<AudioSource>().PlayOneShot(Jump);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("IsStepped", false);
    }
}
