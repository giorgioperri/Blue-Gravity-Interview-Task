using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SlotTypes
{
    Simple,
    Equipped
}

public class InventorySlot : MonoBehaviour
{
    public Item Item;
    [SerializeField] private Image _sprite;
    
    public SlotTypes SlotType;

    private void Start()
    {
        _sprite.color = new Color(1, 1, 1, 0);
    }

    public void SetItem(Item item)
    {
        Item = item;
        _sprite.sprite = item.Icon;
        _sprite.color = new Color(1, 1, 1, 1);

        if (SlotType == SlotTypes.Equipped)
        {
            PlayerController.Instance.EquippedItem = item;
        }
    }
}
