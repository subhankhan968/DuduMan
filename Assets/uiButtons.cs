using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class uiButtons : MonoBehaviour
{
    [SerializeField]
    GameObject shopPanel;
    [SerializeField]
    GameObject menuPanel;

    public void playGame()
    {
        SceneManager.LoadScene("gamePlay");
    }
    public void showShop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
    public void showMenu()
    {
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
