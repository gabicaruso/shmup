﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    public GameObject bullet;
    public Transform arma;

    public float shootDelay = 0.5f;
    private float _lastShootTimestamp = 0.0f;

    private int lifes;
    public AudioClip shootSFX;

    public float leftWall;
    public float rightWall;
    public float bottomWall;
    public float topWall;

    private void Start()
    {
        animator = GetComponent<Animator>();
        lifes = 10;
    }

    public void Shoot()
    {
        if(Time.time - _lastShootTimestamp < shootDelay) return;

        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }

        if(Input.GetAxisRaw("Jump") != 0)
        {
            Shoot();
        }
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
        if (collision.CompareTag("wall"))
        {
            Debug.Log("Bateu numa parede");

            if (transform.position.x < leftWall){
                transform.position = new Vector2 (-8.31f, transform.position.y);
            }
            if (transform.position.x > rightWall){
                transform.position = new Vector2 (8.31f, transform.position.y);
            }
            if (transform.position.y < bottomWall){
                transform.position = new Vector2 (transform.position.x, -5f);
            }
            if (transform.position.y > topWall){
                transform.position = new Vector2 (transform.position.x, 80.5f);
            }
        }
    }
}
