using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private ParticleSystem.EmissionModule fanParticles;
    public AudioSource source;
    public GameStatus gs;

    public float thrust;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        fanParticles = gameObject.GetComponentInChildren<ParticleSystem>().emission;
        gs = GameStatus.GetInstance();

    }

    void FixedUpdate()
    {
        if(Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            //Mouse button is down
            rb.AddForce(Vector2.up * thrust);
            anim.SetBool("FanOn", true);
            fanParticles.enabled = true;
            source.Play();
        }
        else
        {
            anim.SetBool("FanOn", false);
            fanParticles.enabled = false;
            source.Stop();
        }
    }
}
