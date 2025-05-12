using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    internal PlayerManager pManager;

    [SerializeField]
    internal GameObject boi;
    [SerializeField]
    internal GameObject bike;
    [SerializeField]
    internal GameObject bikeRagdoll;

    [SerializeField]
    GameObject petrolBar;
    [SerializeField]
    Image fillImage;

    [SerializeField]
    GameObject pickupGfx;

    bool checkGateTrigger;

    void Start()
    {
        boi.SetActive(true);
        checkGateTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "BikePowerup")
        {
            boi.SetActive(false);
            bike.SetActive(true);

            petrolBar.SetActive(true);
            fillImage.fillAmount = 1f;

            foreach (GameObject jerryCan in GameObject.FindGameObjectsWithTag("Petrol"))
            {
                jerryCan.transform.GetChild(0).gameObject.SetActive(true);
            }

            if (!pManager.soundH.SFXaudioSrc.isPlaying)
            {
                pManager.soundH.SFXaudioSrc.PlayOneShot(pManager.soundH.pickup);
            }
        }

        else if(other.transform.tag == "Petrol")
        {
            if (bike.activeSelf)
            {
                fillImage.fillAmount += 0.5f;
                Instantiate(pickupGfx, other.transform.position, other.transform.rotation);
                other.gameObject.SetActive(false);

                if (!pManager.soundH.SFXaudioSrc.isPlaying)
                {
                    pManager.soundH.SFXaudioSrc.PlayOneShot(pManager.soundH.pickup);
                }
            }
        }

        else if (other.transform.tag == "milkMoney Gate")
        {
            milkMoneyGateInfo gateinfo = other.gameObject.GetComponent<milkMoneyGateInfo>();

            if (checkGateTrigger)
            {
                checkGateTrigger = false;
            }
            else
            {
                checkGateTrigger = true;
            }


            //logic for buying milk
            if (gateinfo.buy && checkGateTrigger)
            {
                if (gateinfo.operation == '+')
                {
                    gameManager.instance.milk += gateinfo.value;
                }
                else
                {
                    if (gameManager.instance.milk == 0)
                    {
                        gameManager.instance.milk = 1;
                    }
                    gameManager.instance.milk *= gateinfo.value;
                }

                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                Instantiate(pManager.milkSplash,new Vector3(other.transform.position.x+5, other.transform.position.y + 5, other.transform.position.z), other.transform.rotation);

                gameManager.instance.maxMilk = gameManager.instance.milk;
            }
            //logic for getting money
            else if (!gateinfo.buy && checkGateTrigger)
            {
                gameManager.instance.milk -= gameManager.instance.maxMilk / 5;

                if (gateinfo.operation == '+')
                {
                    gameManager.instance.money += gateinfo.value * (gameManager.instance.maxMilk / 5);
                }
                else
                {
                    if (gameManager.instance.money == 0)
                    {
                        gameManager.instance.money = 1;
                    }
                    gameManager.instance.money *= gateinfo.value / 2 /** (gameManager.instance.maxMilk / 5)*/;
                }

                if (gameManager.instance.milk < 10)
                {
                    gameManager.instance.milk = 0;
                }

                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                Instantiate(pManager.moneySplash, new Vector3(other.transform.position.x + 5, other.transform.position.y + 5, other.transform.position.z), other.transform.rotation);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Road")
        {
            pManager.isGrounded = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "obstacle")
        {
            boi.GetComponent<Animator>().enabled = false;
            bike.GetComponent<Animator>().enabled = false;

            if (bike.activeSelf)
            {
                bikeRagdoll.SetActive(true);
                bike.SetActive(false);
            }

            pManager.allowMovement = false;

            pManager.failed = true;

            if (!pManager.soundH.SFXaudioSrc.isPlaying)
            {
                pManager.soundH.SFXaudioSrc.PlayOneShot(pManager.soundH.lose);
            }
        }

        else if(collision.transform.tag=="Finish")
        {
            pManager.allowMovement = false;
            pManager.movementH.maxBikeSpeed = 0;
            pManager.movementH.maxRunSpeed = 0;
            pManager.rb.isKinematic = true;

            this.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 4.5f, collision.transform.position.z);

            bike.SetActive(false);
            boi.SetActive(true);

            pManager.finished = true;

            Debug.Log("finished");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        pManager.isGrounded = false;
    }


    void FixedUpdate()
    {
        if (petrolBar.activeSelf && pManager.allowMovement)
        {
            fillImage.fillAmount -= 0.25f / 80; //25% decrease per second

            if (fillImage.fillAmount < 0.01f)
            {
                petrolBar.SetActive(false);

                boi.SetActive(true);
                bike.SetActive(false);

                petrolBar.SetActive(false);

                foreach (GameObject jerryCan in GameObject.FindGameObjectsWithTag("Petrol"))
                {
                    jerryCan.transform.GetChild(0).gameObject.SetActive(false);
                }

                if (!pManager.soundH.SFXaudioSrc.isPlaying)
                {
                    pManager.soundH.SFXaudioSrc.PlayOneShot(pManager.soundH.pickupEnd);
                }
            }
        }
    }
}
