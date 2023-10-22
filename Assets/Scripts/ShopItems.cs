using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : Singleton<ShopItems>
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private RectTransform _hand;

    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemDescription;

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
        _hand.GetComponent<RectTransform>().SetParent(_generatedItems[index].transform);
        _hand.GetComponent<RectTransform>().anchoredPosition = new Vector2(20,100);
        
        _itemName.text = _items[index].ItemName;
        _itemDescription.text = _items[index].Description;
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
