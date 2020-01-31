using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour, IDamageable
{
    private int maxHealth;
    private int currentHealth;
    private int initialGold;
    private int currentGold;

    private int passiveIncome = 5;
    private int passiveIncomeRateInSeconds = 5;
    private float time;

    private bool isDead;

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        initialGold = 20;
        currentGold = initialGold;

        time = 0;

        isDead = false;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > passiveIncomeRateInSeconds)
        {
            currentGold += passiveIncome;
            time = 0;
        }
    }

    public bool CanPurchase(int cost)
    {
        int after = currentGold - cost;

        if (after >= 0)
        {
            currentGold = after;
            return true;
        }

        return false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public int GetLives()
    {
        return currentHealth;
    }

    public int GetGold()
    {
        return currentGold;
    }
}
