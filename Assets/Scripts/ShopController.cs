using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : Singleton<ShopController>
{
    void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameStates.Shop) return;

        if (Input.GetKeyDown(KeyCode.D))
        {
            Shop.Instance.NextItem();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shop.Instance.PreviousItem();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shop.Instance.BuyItem();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShop();
        }
    }
    
    public void OpenShop()
    {
        GameManager.Instance.CurrentGameState = GameStates.Shop;
        GetComponent<Animator>().SetTrigger("OpenShop");
    }
    
    public void CloseShop()
    {
        GameManager.Instance.CurrentGameState = GameStates.Gameplay;
        GetComponent<Animator>().SetTrigger("CloseShop");
    }
}
