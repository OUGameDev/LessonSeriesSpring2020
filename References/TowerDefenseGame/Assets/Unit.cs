using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    NavMeshAgent myAgent;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();

        myAgent.SetDestination(new Vector3(-5, 0, -13));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
