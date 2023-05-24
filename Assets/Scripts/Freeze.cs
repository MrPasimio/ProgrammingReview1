using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    public float freezeDuration = 3f;

    public override void Activate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyController enemyMovement = enemy.GetComponent<EnemyController>();
            if (enemyMovement != null)
            {
                enemyMovement.FreezeMovement(freezeDuration);
            }
        }
    }
}
