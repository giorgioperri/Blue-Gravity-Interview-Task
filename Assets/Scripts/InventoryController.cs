using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : Singleton<InventoryController>
{
    public void OpenInventory()
    {
        GetComponent<Animator>().SetBool("isOpen", true);
    }
    
    public void CloseInventory()
    {
        GetComponent<Animator>().SetBool("isOpen", false);
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameStates.Inventory) return;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
            GameManager.Instance.CurrentGameState = GameStates.Gameplay;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (var slot in GameManager.Instance.InventorySlots.Where(slot => slot.SlotType == SlotTypes.Equipped))
            {
                if (GameManager.Instance.InventorySlots[0].Item == null) return;
                
                Item temp = slot.Item;
                slot.SetItem(GameManager.Instance.InventorySlots[0].Item);
                GameManager.Instance.InventorySlots[0].SetItem(temp);  
                return;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (var slot in GameManager.Instance.InventorySlots.Where(slot => slot.SlotType == SlotTypes.Equipped))
            {
                if (GameManager.Instance.InventorySlots[1].Item == null) return;
                
                Item temp = slot.Item;
                slot.SetItem(GameManager.Instance.InventorySlots[1].Item);
                GameManager.Instance.InventorySlots[1].SetItem(temp);  
                return;
            }
        }
    }
}
