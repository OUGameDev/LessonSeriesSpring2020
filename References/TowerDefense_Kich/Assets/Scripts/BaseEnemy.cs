using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    protected int maxHealth = 10;
    protected int currentHealth;
    protected float speed = 1f;

    protected Player player;
    protected WaveManager waveManager;
    protected NavMeshAgent agent;
    protected GameObject spawn;
    protected GameObject destination;

    private float agentStoppingDistance = 2f;


    protected bool isDead;

    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Player>();
        waveManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WaveManager>();
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        destination = GameObject.FindGameObjectWithTag("Destination");

        agent = GetComponent<NavMeshAgent>();

        agent.stoppingDistance = agentStoppingDistance;
        agent.SetDestination(destination.transform.position);
        
        isDead = false;
    }

    protected void Update()
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

    protected virtual bool HasReachedDestination()
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

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    private void OnDestroy()
    {
        waveManager.numEnemiesAlive--;
    }
}
