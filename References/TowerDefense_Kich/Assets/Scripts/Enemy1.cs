﻿public class Enemy1 : BaseEnemy
{
    private new void Start()
    {
        base.Start();

        maxHealth = 5;
        currentHealth = maxHealth;
        speed = 3f;
        agent.speed = speed;
    }

    private new void Update()
    {
        base.Update();
    }
}
