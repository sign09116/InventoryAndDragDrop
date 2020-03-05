using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAsset : MonoBehaviour
{
    public static ItemAsset Instance { get; set; }
    private void Awake()
    {
        Instance = this;


    }
    public Transform PFItemWorld;
    public Sprite SwordSprite, HelathPotionSprite, ManaPotionSprite, CoinSprite;

}
