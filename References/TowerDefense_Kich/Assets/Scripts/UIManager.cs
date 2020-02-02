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

    private ItemSelect item;

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
                item = ItemSelect.barrier;
                store.PurchaseBuilding(item);
            }
            if (store.item == ItemSelect.sell)
            {
                store.SellBuilding();
            }
        }
    }

    private void UpdateTexts()
    {
        livesTxt.text = "Lives: " + player.GetLives();
        goldTxt.text = "Gold: " + player.GetGold();
    }

    public void OnCancelBtn()
    {
        store.item = ItemSelect.clear;
    }

    public void OnBarrierBtn()
    {
        store.item = ItemSelect.barrier;
    }

    public void OnSellBtn()
    {
        store.item = ItemSelect.sell;
    }
}
