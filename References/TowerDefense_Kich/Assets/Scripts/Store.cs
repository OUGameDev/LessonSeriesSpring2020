using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ItemSelect { barrier };

public class Store : MonoBehaviour
{
    private BuildManager buildManager;
    private Player player;

    public ItemSelect item;

    public GameObject barrierPrefab;
    private int barrierCost = 5;

    private const float RAYDIST = 1000f;

    private void Start()
    {
        buildManager = GetComponent<BuildManager>();
        player = GetComponent<Player>();
    }

    public void PurchaseBarrier()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, RAYDIST))
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
