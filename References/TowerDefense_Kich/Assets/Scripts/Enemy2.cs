using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : BaseEnemy
{
    private new void Start()
    {
        base.Start();

        maxHealth = 7;
        currentHealth = maxHealth;
        speed = 5f;
        agent.speed = speed;
    }

    private new void Update()
    {
        base.Update();
    }
}
