using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milkFarmManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] addSpriteArr;
    [SerializeField]
    private Sprite[] mulSpriteArr;
    [SerializeField]
    private int[] Spritevalues;
    [SerializeField]
    private GameObject[] gatesArr;

    int checkIndex;
    [SerializeField]
    bool buyMilk;

    void Start()
    {
        checkIndex = 0;
        int gateArrLen = gatesArr.Length;

        Sprite sprite1, spriteOld = addSpriteArr[0];

        for (int i = 0; i < gateArrLen; i++)
        {
            milkMoneyGateInfo gateInfo = gatesArr[i].GetComponent<milkMoneyGateInfo>();

            int typeChoice = Random.Range(0, 2);//0 for add, 1 for multiply

            do
            {
                int index = 0;
                if (typeChoice == 0)
                {
                    index = Random.Range(0, addSpriteArr.Length);
                    sprite1 = addSpriteArr[index];
                    gateInfo.operation = '+';
                }
                else
                {
                    index = Random.Range(0, mulSpriteArr.Length);
                    sprite1 = mulSpriteArr[index];
                    gateInfo.operation = '*';
                }

                gateInfo.value = Spritevalues[(addSpriteArr.Length * typeChoice) + index];
                gateInfo.buy = buyMilk;

            } while (sprite1 == spriteOld && i > 0);


            gatesArr[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprite1;

            spriteOld = sprite1;
        }
    }

    void Update()
    {
        if (gatesArr[checkIndex].GetComponent<BoxCollider>().enabled == false)
        {
            gatesArr[checkIndex + 1].GetComponent<BoxCollider>().enabled = false;

            if (checkIndex + 2 < gatesArr.Length)
            {
                checkIndex += 2;
            }
        }
        else if(gatesArr[checkIndex + 1].GetComponent<BoxCollider>().enabled == false)
        {
            gatesArr[checkIndex].GetComponent<BoxCollider>().enabled = false;

            if (checkIndex + 2 < gatesArr.Length)
            {
                checkIndex += 2;
            }
        }
    }
}


