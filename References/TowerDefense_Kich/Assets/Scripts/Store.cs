using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Store : MonoBehaviour
{
    private BuildManager buildManager;
    private Player player;
    private UIManager ui;

    public GameObject barrierPrefab;
    private int barrierCost = 5;


    private float rayDist = 1000f;

    private void Start()
    {
        buildManager = GetComponent<BuildManager>();
        player = GetComponent<Player>();
        ui = GetComponent<UIManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (ui.isBarrierSelected)
            {
                BuildBarrier();
            }
        }
    }

    private void BuildBarrier()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDist))
        {
            // Select node
            if (hit.collider.gameObject.tag == "Node")
            {
                Node node = hit.collider.gameObject.GetComponent<Node>();

                // Check if node is free
                if (node.IsOccupied())
                {
                    Debug.Log("Occupied node");
                }
                // Check if player has enough gold to purchase
                if (player.CanPurchase(barrierCost))
                {
                    Debug.Log("Purchased barrier");

                    buildManager.Build(node, barrierPrefab);
                }
                else
                {
                    Debug.Log("Not enough gold");
                }
            }
            else
            {
                Debug.Log("Cannot place barrier on " + hit.collider.name);
            }
        }
    }
}
