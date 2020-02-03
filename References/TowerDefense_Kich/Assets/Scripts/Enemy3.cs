using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : BaseEnemy
{
    private new void Start()
    {
        base.Start();

        maxHealth = 20;
        currentHealth = maxHealth;
        speed = 10f;
        agent.speed = speed;
    }

    private new void Update()
    {
        base.Update();
    }
}
