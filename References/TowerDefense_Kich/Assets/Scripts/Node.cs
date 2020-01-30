using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Vector3 buildPosition;
    private bool isOccupied;

    private void Start()
    {
        buildPosition = transform.position + new Vector3(0, 1f, 0);
        isOccupied = false;
    }

    public Vector3 GetBuildPosition()
    {
        return buildPosition;
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }
}
