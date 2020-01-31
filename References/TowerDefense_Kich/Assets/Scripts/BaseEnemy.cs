using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    protected int maxHealth = 10;
    protected int currentHealth;
    protected float speed = 1f;

    protected Player player;
    protected NavMeshAgent agent;
    protected GameObject destination;

    protected bool isDead;

    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        destination = GameObject.FindGameObjectWithTag("Destination");

        agent.SetDestination(destination.transform.position);
        
        isDead = false;
    }


    protected bool HasReachedDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
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
            isDead = true;
        }
    }
}
