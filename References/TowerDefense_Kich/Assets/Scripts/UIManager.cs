using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private Player player;
    private Store store;

    public TextMeshProUGUI livesTxt;
    public TextMeshProUGUI goldTxt;
    public TextMeshProUGUI waveTxt;

    public Button BarrierBtn;

    private void Start()
    {
        player = GetComponent<Player>();
        store = GetComponent<Store>();
    }

    private void Update()
    {
        UpdateTexts();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (store.item == ItemSelect.barrier)
            {
                store.PurchaseBarrier();
            }
        }
    }

    private void UpdateTexts()
    {
        livesTxt.text = "Lives: " + player.GetLives();
        goldTxt.text = "Gold: " + player.GetGold();
    }

    public void OnBarrierBtn()
    {
        store.item = ItemSelect.barrier;
    }
}
