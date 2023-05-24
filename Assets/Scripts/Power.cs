using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Power : Pickup
{
    public float powerDuration = 5f;
    public Sprite poweredSprite;
    public GameObject enemyPrefab;

    private Player player;
    private SpriteRenderer playerRenderer;

    public override void Activate()
    {
        player = FindObjectOfType<Player>();
        player.isPowered = true;
        playerRenderer = player.GetComponent<SpriteRenderer>();
        playerRenderer.sprite = poweredSprite;

        StartCoroutine(PowerTimer());
    }

    private System.Collections.IEnumerator PowerTimer()
    {
        yield return new WaitForSeconds(powerDuration);

        player.isPowered = false;
        playerRenderer.sprite = player.normalSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && player.isPowered)
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Activate();
            StartCoroutine(DelayedDestroy());
        }
    }
}
