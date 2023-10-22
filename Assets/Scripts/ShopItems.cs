using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : Singleton<ShopItems>
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private RectTransform _hand;

    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemDescription;
    [SerializeField] private TextMeshProUGUI _itemPrice;

    [HideInInspector] public int ItemIndex = 0;
    
    private List<GameObject> _generatedItems = new List<GameObject>();

    void OnEnable()
    {
        GenerateItems();
    }

    void GenerateItems()
    {
        //destroy all children
        foreach (Transform child in transform)
        {
            if(child.gameObject.tag != "Hand") Destroy(child.gameObject);
        }
        
        _generatedItems.Clear();

        foreach (var item in _items)
        {
            GameObject currentItem = new GameObject();
            Image image = currentItem.AddComponent<Image>();

            image.sprite = item.Icon;
            
            currentItem.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            currentItem.transform.SetParent(transform);
            
            _generatedItems.Add(currentItem);
        }

        SetHandPosition(ItemIndex);
    }
    
    public void SetHandPosition(int index)
    {
        if (_items.Count == 0)
        {
            Destroy(_hand);
            return;
        };
        
        _hand.GetComponent<RectTransform>().SetParent(_generatedItems[index].transform);
        _hand.GetComponent<RectTransform>().anchoredPosition = new Vector2(20,100);
        
        _itemName.text = _items[index].ItemName;
        _itemDescription.text = _items[index].Description;
        _itemPrice.text = _items[index].Price.ToString();
        
        foreach (var item in _items)
        {
            item.HoveredInShop = false;
        }
        
        _items[index].HoveredInShop = true;
        _hand.GetComponent<Image>().enabled = true;
    }
    
    public void BuyItem()
    {
        if (_items.Count == 0) return;

        if (_items.Any(item => item.HoveredInShop && GameManager.Instance.CurrentGold >= _items[ItemIndex].Price))
        {
            GameManager.Instance.Pay(_items[ItemIndex].Price);
            GameManager.Instance.PlayerInventory.Add(_items[ItemIndex]);
            _items[ItemIndex].HoveredInShop = false;
            _items.RemoveAt(ItemIndex);
            ItemIndex = 0;
            SetHandPosition(ItemIndex);
            GenerateItems();
        }
    }

    public void NextItem()
    {
        ItemIndex++;
        if (ItemIndex >= _items.Count) ItemIndex = 0;
        SetHandPosition(ItemIndex);
    }
    
    public void PreviousItem()
    {
        ItemIndex--;
        if (ItemIndex < 0) ItemIndex = _items.Count - 1;
        SetHandPosition(ItemIndex);
    }
}
