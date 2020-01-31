using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : BaseEnemy
{
    private new void Start()
    {
        base.Start();

        maxHealth = 5;
        currentHealth = maxHealth;
        speed = 3f;
        agent.speed = speed;
    }

    private void Update()
    {
        if (isDead)
        {
            Destroy(gameObject);
            return;
        }
        if (HasReachedDestination())
        {
            Destroy(gameObject);
            player.TakeDamage(currentHealth);
            return;
        }
    }
}
