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
    private GameObject particleSystem;
    public AudioSource bounceSound;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        particleSystem = transform.GetChild(0).gameObject;

    }
    public void Bounce()
    {
        Rb.velocity = new Vector3(0, BounceSpeed, 0);
        bounceSound.Play();
    }
    public void Die()
    {
        Rb.velocity = Vector3.zero;
        game.OnPlayerDied();
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
            particleSystem.SetActive(true);
            rage = true;
        }
        else
        {
            particleSystem.SetActive(false);
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
