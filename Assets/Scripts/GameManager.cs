using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public TextMeshProUGUI playerLivesDisplay;
    public float respawnDelay = 3f;
    public GameObject playerObject;
    public Sprite regularSprite;
    public Sprite deadSprite;

    private bool isPlayerDead = false;
    private bool isGameOver = false;
    private Vector3 respawnPosition;

    private void Start()
    {
        UpdatePlayerLivesDisplay();
        respawnPosition = playerObject.transform.position;
    }

    public void IncreasePlayerScore(int amount)
    {
        if (!isPlayerDead && !isGameOver)
        {
            // Add your scoring logic here
        }
    }

    public void DecreasePlayerLives(int amount)
    {
        if (!isPlayerDead && !isGameOver)
        {
            playerLives -= amount;
            UpdatePlayerLivesDisplay();

            if (playerLives <= 0)
            {
                GameOver();
            }
            else
            {
                StartRespawnTimer(respawnDelay);
            }
        }
    }

    public void StartRespawnTimer(float delay)
    {
        if (!isPlayerDead && !isGameOver)
        {
            StartCoroutine(RespawnTimer(delay));
        }
    }

    private IEnumerator RespawnTimer(float delay)
    {
        isPlayerDead = true;
        yield return new WaitForSeconds(delay);

        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.Respawn();
        }

        isPlayerDead = false;
    }

    public Vector3 GetRandomRespawnPosition()
    {
            // Calculate the minimum and maximum coordinates for X and Y
            float minX = 0.5f;
            float maxX = 0.5f;
            float minY = 0.5f;
            float maxY = 0.5f;

            // Generate random coordinates within the spawn area range
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            // Return the random spawn position
            return new Vector3(randomX, randomY, 0f);
    }

    private void UpdatePlayerLivesDisplay()
    {
        playerLivesDisplay.text = "Lives: " + playerLives.ToString();
    }

    private void GameOver()
    {
        isGameOver = true;
        // Add your game over logic here, such as displaying a game over screen or stopping the game
    }

    public bool IsPlayerDead()
    {
        return isPlayerDead;
    }
}

