using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    float jumpPower = 16f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] GameObject panel;
    [SerializeField] GameObject restartButton;
    [SerializeField] AudioSource bgAudioSource;
    [SerializeField] AudioSource dieSource;
    GameObject backGround;
    void Start()
    {
        panel = GameObject.Find("Panel");
        restartButton = GameObject.Find("RestartButton");
        backGround = GameObject.Find("Background");
        bgAudioSource = backGround.GetComponent<AudioSource>();

        panel.SetActive(false);
        restartButton.SetActive(false);
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
           rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);

        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

        }

    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            dieSource.Play();
            bgAudioSource.Stop();
            panel.SetActive(true);
            restartButton.SetActive(true );
            Time.timeScale = 0f;
        }

    }

}


