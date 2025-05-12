using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI milkText, moneyText, currLvl, nextLvl;

    [SerializeField]
    Image progressBar;

    [SerializeField]
    Transform finishLine;
    [SerializeField]
    Transform player;

    //Transform initialPos;

    private void Start()
    {
        currLvl.text = (PlayerPrefs.GetInt("currLvl") + 1).ToString();
        nextLvl.text = (PlayerPrefs.GetInt("currLvl") + 2).ToString();
    }

    private void Update()
    {
        progressBar.fillAmount = player.position.z / 1250;
    }

    private void FixedUpdate()
    {
        milkText.text = gameManager.instance.milk.ToString();
        moneyText.text = gameManager.instance.money.ToString();
    }
}
