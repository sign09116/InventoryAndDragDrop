using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpwaner : MonoBehaviour
{
    public UIItem item;
    private void Awake()
    {

    }
    private void Start()
    {
        ItemWorld.SpwanItemWorld(transform.position, item);
        Destroy(gameObject);
    }
}
