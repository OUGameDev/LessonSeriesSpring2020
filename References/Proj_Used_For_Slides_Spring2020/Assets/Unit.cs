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

        Vector3 destination = new Vector3(9.5f, 1, -13);

        myAgent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
