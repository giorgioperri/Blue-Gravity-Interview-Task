using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private Animator _bubbleAnim;
    [SerializeField] private GameObject _shopUI;

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
            _shopUI.SetActive(true);
            _bubbleAnim.SetBool("IsVisible", false);
        }
    }
}
