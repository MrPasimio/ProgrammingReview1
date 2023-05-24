using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Pickup : GameManager
{
    protected Collider2D pickupCollider;
    protected SpriteRenderer pickupRenderer;

    private void Start()
    {
        pickupCollider = GetComponent<Collider2D>();
        pickupRenderer = GetComponent<SpriteRenderer>();
    }

    public abstract void Activate();

    protected System.Collections.IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(5.0f);

        pickupCollider.enabled = false;
        pickupRenderer.enabled = false;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Activate();
            StartCoroutine(DelayedDestroy());
        }
    }
}

