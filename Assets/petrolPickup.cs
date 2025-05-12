using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petrolPickup : MonoBehaviour
{
    [SerializeField]
    GameObject pickupAppearGfx;
    private void OnEnable()
    {
        Instantiate(pickupAppearGfx, this.gameObject.transform);
    }
}
