using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public enum GameStates
{
    Gameplay,
    Shop,
    Inventory
}

public class GameManager : PersistentSingleton<GameManager>
{
    public GameStates CurrentGameState = GameStates.Gameplay;
    public int CurrentGold = 99;
    
    [SerializeField] private TextMeshProUGUI _currentGoldText;
    public List<Item> PlayerInventory;
    [SerializeField] private List<InventorySlot> _inventorySlots;

    private void Start()
    {
        _currentGoldText.text = CurrentGold.ToString();
    }

    public void Pay(int amount)
    {
        CurrentGold -= amount;
        _currentGoldText.text = CurrentGold.ToString();
    }
    
    public void AddToInventory(Item item)
    {
        PlayerInventory.Add(item);

        foreach (var slot in _inventorySlots.Where(slot => slot.SlotType == SlotTypes.Equipped && slot.Item == null))
        {
            slot.SetItem(item);
            return;
        }
        
        foreach (var slot in _inventorySlots.Where(slot => slot.SlotType == SlotTypes.Simple && slot.Item == null))
        {
            slot.SetItem(item);
            return;
        }
    }
}
