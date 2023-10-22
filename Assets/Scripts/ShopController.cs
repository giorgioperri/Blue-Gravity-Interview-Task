using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    void Start()
    {
        //gameObject.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameStates.Shop) return;

        if (Input.GetKeyDown(KeyCode.D))
        {
            ShopItems.Instance.NextItem();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShopItems.Instance.PreviousItem();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShopItems.Instance.BuyItem();
        }
    }
}
