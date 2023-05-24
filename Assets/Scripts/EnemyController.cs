using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform player;
    public GameManager gameManager;

    private Rigidbody2D rb;
    private bool isFrozen = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player != null && !gameManager.IsPlayerDead())
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void FreezeMovement(float duration)
    {
        if (!isFrozen)
        {
            isFrozen = true;

            StartCoroutine(UnfreezeMovement(duration));
        }
    }

    private System.Collections.IEnumerator UnfreezeMovement(float duration)
    {
        yield return new WaitForSeconds(duration);

        isFrozen = false;
    }


private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerController = collision.gameObject.GetComponent<Player>();
            if (playerController != null && !gameManager.IsPlayerDead())
            {
                playerController.Die();
            }
        }
    }
}
