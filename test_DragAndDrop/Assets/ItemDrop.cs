using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    public GameObject Dropitem;
    public Slotmanager slotmanager;
    public Button SlotButton;
    public static int i;
    private void Awake()
    {
        slotmanager = GameObject.FindObjectOfType<Slotmanager>();
        SlotButton = GetComponent<Button>();

    }
    public void GetDropItem(GameObject dropitem)
    {
        this.Dropitem = dropitem;
        Debug.Log("haveItem");
        SlotButton.onClick.AddListener(Dropitem.GetComponent<ItemDrag>().useItem);

    }




    public void OnDrop(PointerEventData eventData)
    {

        if (transform.childCount > 0)
        {
            i++;
            Dropitem.transform.SetParent(slotmanager.Slot[i].transform);
            Dropitem.transform.position = slotmanager.Slot[i].transform.position;

        }
        else
        {
            Dropitem.transform.SetParent(transform);
            Dropitem.transform.position = transform.position;
        }
    }
}
