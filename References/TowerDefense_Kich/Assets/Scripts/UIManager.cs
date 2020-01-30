using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private Player player;

    public TextMeshProUGUI livesTxt;
    public TextMeshProUGUI goldTxt;
    public TextMeshProUGUI waveTxt;

    public Button BarrierBtn;
    public bool isBarrierSelected;

    private void Start()
    {
        player = GetComponent<Player>();

        isBarrierSelected = false;
    }

    private void Update()
    {
        livesTxt.text = "Lives: " + player.GetLives();
        goldTxt.text = "Gold: " + player.GetGold();
    }

    public void OnBarrierBtn()
    {
        isBarrierSelected = true;

        // Set others to false
    }
}
