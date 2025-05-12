using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static int currPrev;

    public Material shirtMat;
    public Material pantMat;
    public Material[] ShirtSkins;
    public Material[] PantSkins;

    public int[] SkinPrices;
    public bool[] unlocked;

    private void Start()
    {

        unlocked[0] = true;
        for (int i = 1; i < 5; i++)
        {
            string skin = "skin" + i.ToString();

            if (PlayerPrefs.GetInt(skin) == 1)
            {
                unlocked[i] = true;
            }
            else
            {
                unlocked[i] = false;
            }
        }
    }

    private void OnEnable()
    {
        currPrev = 0;
        changeSkin(PlayerPrefs.GetInt("selectedSkin"));
    }
    private void OnDisable()
    {
        changeSkin(PlayerPrefs.GetInt("selectedSkin"));
    }
    
    public void changeSkin(int index)
    {
        shirtMat.SetColor("_Color", ShirtSkins[index].color);
        pantMat.SetColor("_Color", PantSkins[index].color);

        Debug.Log(index);
    }
}
