using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : Singleton<ShopKeeper>
{
    [SerializeField] private Animator _bubbleAnim;

    private bool _canShop;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _bubbleAnim.SetBool("IsVisible", true);
            _canShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _bubbleAnim.SetBool("IsVisible", false);
            _canShop = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canShop)
        {
            GameManager.Instance.CurrentGameState = GameStates.Shop;
            ShopController.Instance.OpenShop();
            _bubbleAnim.SetBool("IsVisible", false);
            _canShop = false;
        }
    }
    
    public void DisableShop()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
