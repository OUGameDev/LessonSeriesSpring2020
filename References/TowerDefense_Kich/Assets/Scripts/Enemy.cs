using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    private Player player;

    private NavMeshAgent agent;
    private GameObject end;

    public float speed;
    public int maxHealth;
    private int currentHealth;

    private bool isDead;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        end = GameObject.FindGameObjectWithTag("Destination");

        agent.SetDestination(end.transform.position);
        agent.speed = speed;

        currentHealth = maxHealth;
        isDead = false;
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

    private bool HasReachedDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Dead
            isDead = true;
        }
    }
}
