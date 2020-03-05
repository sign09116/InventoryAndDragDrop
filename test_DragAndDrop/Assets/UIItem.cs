using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class UIItem
{
    public enum Itemtype
    {
        Sword,
        HelathPotion,
        ManaPotion,
        Coin,
    }
    public Itemtype itemtype;
    public int amount;
    public Sprite GetSprite()
    {
        switch (itemtype)
        {
            default:
            case Itemtype.Sword: return ItemAsset.Instance.SwordSprite;
            case Itemtype.HelathPotion: return ItemAsset.Instance.HelathPotionSprite;
            case Itemtype.ManaPotion: return ItemAsset.Instance.ManaPotionSprite;
            case Itemtype.Coin: return ItemAsset.Instance.CoinSprite;

        }
    }
    public Color GetColor()
    {
        switch (itemtype)
        {
            default:
            case Itemtype.Sword: return Color.gray;
            case Itemtype.HelathPotion: return Color.red;
            case Itemtype.ManaPotion: return Color.blue;
            case Itemtype.Coin: return Color.yellow;

        }
    }
    public bool isStackable()
    {
        switch (itemtype)
        {
            default:
            case Itemtype.Sword:
                return false;
            case Itemtype.HelathPotion:
            case Itemtype.ManaPotion:
            case Itemtype.Coin:
                return true;
        }
    }
}

