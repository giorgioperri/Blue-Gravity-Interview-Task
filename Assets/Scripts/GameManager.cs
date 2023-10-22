using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        _currentGoldText.text = CurrentGold.ToString();
        PlayerInventory = new List<Item>();
    }

    public void Pay(int amount)
    {
        CurrentGold -= amount;
        _currentGoldText.text = CurrentGold.ToString();
    }
}
