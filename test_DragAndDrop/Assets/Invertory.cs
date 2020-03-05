using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertory
{
    public event EventHandler onItemListChange;
    List<UIItem> itemList;

    public Invertory()
    {
        itemList = new List<UIItem>();
        AddItem(new UIItem { itemtype = UIItem.Itemtype.Sword, amount = 1 });
        AddItem(new UIItem { itemtype = UIItem.Itemtype.HelathPotion, amount = 1 });
        AddItem(new UIItem { itemtype = UIItem.Itemtype.ManaPotion, amount = 1 });
        AddItem(new UIItem { itemtype = UIItem.Itemtype.Coin, amount = 1 });
        Debug.Log(itemList.Count);
        //Debug.Log("Invertory");
    }
    public void AddItem(UIItem item)
    {
        if (item.isStackable())
        {
            bool ItemAlreadyInInventory = false;
            foreach (UIItem inventoryItem in itemList)
            {

                if (inventoryItem.itemtype == item.itemtype)
                {
                    inventoryItem.amount += item.amount;
                    ItemAlreadyInInventory = true;
                }
            }
            if (!ItemAlreadyInInventory)
            {
                itemList.Add(item);
            }

        }
        else
        {

            itemList.Add(item);
        }
        onItemListChange?.Invoke(this, EventArgs.Empty);
    }
    public List<UIItem> GetIItemList()
    {
        return itemList;
    }
}
