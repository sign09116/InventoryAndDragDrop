using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotmanager : MonoBehaviour
{
    public GameObject[] Slot;
    private void Awake()
    {
        Slot = GameObject.FindGameObjectsWithTag("Slot");

    }
}
