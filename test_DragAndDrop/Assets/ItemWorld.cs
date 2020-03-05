using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpwanItemWorld(Vector3 Postion, UIItem item)
    {
        Transform transform = Instantiate(ItemAsset.Instance.PFItemWorld, Postion, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }
    UIItem item;
    SpriteRenderer spriteRenderer;
    Text UItext;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UItext = transform.Find("Canvas").Find("Text").GetComponent<Text>();
    }
    public void SetItem(UIItem item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();

        if (item.amount > 1)
        {
            UItext.text = item.amount.ToString();
        }
        else
        {
            UItext.text = "";
        }

    }
    public UIItem GetItem()
    {
        return item;
    }
    public void DestroySelf()

    {
        Destroy(gameObject, 0.2f);
    }
}
