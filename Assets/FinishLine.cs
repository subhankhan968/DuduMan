using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            PlayerPrefs.SetInt("totalMoney", PlayerPrefs.GetInt("totalMoney") + gameManager.instance.money);
            PlayerPrefs.SetInt("currLvl", PlayerPrefs.GetInt("currLvl") + 1);
        }
    }
}
