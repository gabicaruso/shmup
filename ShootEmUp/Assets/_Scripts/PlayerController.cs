using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    public GameObject bullet;
    public Transform arma;

    public float shootDelay = 0.5f;
    private float _lastShootTimestamp = 0.0f;

    public int lifes;
    public AudioClip shootSFX;

    public GameObject menuPause;

    private void Start()
    {
        animator = GetComponent<Animator>();
        lifes = 4;
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
        if (lifes <= 0)  Die();
    }

    public void Die()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FimDeJogo");
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

        if (lifes == 4) {
            animator.SetFloat("Demage", 0.0f);
        }
        else if (lifes == 3) {
            animator.SetFloat("Demage", 1.0f);
        }
        else if (lifes == 2) {
            animator.SetFloat("Demage", 2.0f);
        }
        else if (lifes == 1) {
            animator.SetFloat("Demage", 3.0f);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0f;
            menuPause.SetActive(true);
        }
    }

    public void Continue(){
        Time.timeScale = 1f;
        menuPause.SetActive(false);
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
            //Debug.Log("Bateu numa parede");
        }
    }
}
