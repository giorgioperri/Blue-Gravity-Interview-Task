using System;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
}

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [HideInInspector] public string ItemName;
    [HideInInspector] public bool HoveredInShop;
    
    public String Description;
    public Sprite Icon;
    public ItemType itemType;
    public int ID;
    
    private void OnValidate()
    {
        ItemName = name;
    }
}