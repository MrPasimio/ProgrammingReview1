using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameManager gameManager;
    public Sprite regularSprite;
    public Sprite deadSprite;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isPlayerDead)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * moveSpeed;
        }
    }

    public void Die()
    {
        isPlayerDead = true;
        spriteRenderer.sprite = deadSprite;
        gameManager.DecreasePlayerLives(1);
        gameManager.StartRespawnTimer(1);
    }

    public void Respawn()
    {
        isPlayerDead = false;
        spriteRenderer.sprite = regularSprite;
        transform.position = gameManager.GetRandomRespawnPosition();
    }
}
