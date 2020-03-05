using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIIntervertory : MonoBehaviour
{
    Invertory invertory;
    Transform itemSlot, itemSlotTemp;


    private void Awake()
    {
        itemSlot = transform.Find("ItemSlot");
        itemSlotTemp = itemSlot.Find("ItemSlottemp");

    }
    public void SetInventory(Invertory invertory)
    {
        this.invertory = invertory;
        invertory.onItemListChange += Invertory_onItemListChange;
        RefreshInvenToryItems();
    }

    private void Invertory_onItemListChange(object sender, EventArgs e)
    {
        RefreshInvenToryItems();
    }

    void RefreshInvenToryItems()
    {
        foreach (Transform child in itemSlot)
        {
            if (child == itemSlotTemp) continue;
            Destroy(child.gameObject);


        }
        int x = 0;
        int y = 0;
        float itemSlotCellsize = 60f;
        foreach (UIItem uIItem in invertory.GetIItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemp, itemSlot).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellsize, y * itemSlotCellsize);
            Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
            image.sprite = uIItem.GetSprite();

            Text Amounttext = itemSlotRectTransform.Find("ItemAmountText").GetComponent<Text>();
            if (uIItem.amount > 1)
            {
                Amounttext.text = uIItem.amount.ToString();
            }
            else
            {
                Amounttext.text = "";
            }

            x++;
            if (x > 0)
            {
                x = 0;
                y--;
            }
        }
    }
}
