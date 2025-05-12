using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public SkinManager skinManager;

    public GameObject toUnlock;
    public GameObject toSelect;
    public TextMeshProUGUI unlockText;

    private void Start()
    {
        updateMoneyText();
        skinManager.changeSkin(SkinManager.currPrev);
    }

    private void Update()
    {
        if (skinManager.unlocked[SkinManager.currPrev])
        {
            toSelect.SetActive(true);
            toUnlock.SetActive(false);

            if (PlayerPrefs.GetInt("selectedSkin") == SkinManager.currPrev)
            {
                unlockText.text = "Selected";
            }
            else
            {
                unlockText.text = "Select";
            }
        }
        else
        {
            toSelect.SetActive(false);
            toUnlock.SetActive(true);
            unlockText.text = skinManager.SkinPrices[SkinManager.currPrev].ToString();
        }
    }

    public void unlockButton()
    {
        if(skinManager.SkinPrices[SkinManager.currPrev] <= PlayerPrefs.GetInt("totalMoney"))
        {
            skinManager.unlocked[SkinManager.currPrev] = true;

            PlayerPrefs.SetInt("totalMoney", PlayerPrefs.GetInt("totalMoney") - skinManager.SkinPrices[SkinManager.currPrev]);
            string temp = "skin" + SkinManager.currPrev;
            PlayerPrefs.SetInt(temp, 1);
        }

        toSelect.SetActive(true);
        toUnlock.SetActive(false);

        selectButton();
    }

    public void selectButton()
    {
        PlayerPrefs.SetInt("selectedSkin", SkinManager.currPrev);
        skinManager.changeSkin(SkinManager.currPrev);
    }

    public void nextSkin()
    {
        SkinManager.currPrev++;
        if (SkinManager.currPrev >= 5)
        {
            SkinManager.currPrev = 0;
        }

        skinManager.changeSkin(SkinManager.currPrev);
    }
    public void prevSkin()
    {
        SkinManager.currPrev--;
        if (SkinManager.currPrev < 0)
        {
            SkinManager.currPrev = 4;
        }

        skinManager.changeSkin(SkinManager.currPrev);
    }


    public void updateMoneyText()
    {
        moneyText.text = PlayerPrefs.GetInt("totalMoney").ToString();
    }
}
