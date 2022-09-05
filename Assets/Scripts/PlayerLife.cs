using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private int _lifeCounter = 3;

    [SerializeField] private AudioSource deathSoundEffect;



    public int NumOfLives
    {
        get { return _lifeCounter; }
        set { _lifeCounter = value; }
    }

    public void AddLife()
    {
        NumOfLives++;
    }

    public void RemoveLife()
    {
        if (_lifeCounter > 0)
            NumOfLives--;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
