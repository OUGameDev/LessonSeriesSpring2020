using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildManager : MonoBehaviour
{
    public NavMeshSurface surface;


    public void Build(Node node, GameObject building)
    {
        Vector3 position = node.GetBuildPosition();

        Instantiate(building, position, Quaternion.identity);
        surface.BuildNavMesh();
    }
}
