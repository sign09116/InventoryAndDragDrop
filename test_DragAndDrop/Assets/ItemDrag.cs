using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject IBeginDragObj;
    Vector3 startPostion;
    public CanvasGroup Slotgroup;
    public Transform startParent;
    public ItemDrop m_temDrop;
    public float Dis;

    Text amount;

    private void Awake()
    {
        amount = transform.Find("ItemAmountText").GetComponent<Text>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        IBeginDragObj = gameObject;

        startPostion = transform.position;
        startParent = transform.parent;
        Slotgroup = GameObject.Find("ItemBOX (2)").GetComponent<CanvasGroup>();
        m_temDrop = GameObject.Find("ItemBOX (2)").GetComponentInChildren<ItemDrop>();
        m_temDrop.GetDropItem(IBeginDragObj);
        Slotgroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
        Dis = Vector3.Distance(gameObject.transform.position, startPostion);
        print(Dis);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Slotgroup.blocksRaycasts = true;
        IBeginDragObj = null;
        if (Dis < 200)
        {
            transform.position = startPostion;
        }
        else
        {
            m_temDrop.OnDrop(eventData);
        }
    }
    public void useItem()
    {
        // print();
        // if ()
        // {

        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }
    public void checkedItemAmount(int amount)
    {
        print(amount);
    }


}


