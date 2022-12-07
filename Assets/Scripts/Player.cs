using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody Rb;
    public float BounceSpeed;
    public Platform currentPlatform;
    public Game game;
    public bool rage = false;
    private GameObject RageparticleSystem;
    private GameObject FallparticleSystem;


    public AudioSource bounceSound;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        RageparticleSystem = transform.GetChild(0).gameObject;
        FallparticleSystem = transform.GetChild(1).gameObject;
        FallparticleSystem.SetActive(false);

    }
    public void Bounce()
    {
        Rb.velocity = new Vector3(0, BounceSpeed, 0);
        bounceSound.Play();
    }
    public void Die()
    {
        Rb.velocity = Vector3.zero;
        Rb.isKinematic = true;
        game.OnPlayerDied();
        FallparticleSystem.SetActive(true);
    }
    public void getFinish()
    {
        Rb.velocity = Vector3.zero;
        game.OnPlayerFinish();
    }
    public void AddPoints(int coefficient)
    {
        game.AddPoints(coefficient);
    }
    private void Rage()
    {
        if (Rb.velocity.y < -30)
        {
            RageparticleSystem.SetActive(true);
            rage = true;
        }
        else
        {
            RageparticleSystem.SetActive(false);
            rage = false;
        }
    }
    public void disableRage()
    {
        rage = false;
    }
    private void Update()
    {
        Rage();
    }
}
