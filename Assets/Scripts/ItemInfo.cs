using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo 
{
    public GameObject itemObj;
    public string itemName;
    public string itemCode;
    public string itemType;
    private int maxAmount;
    public int itemAmount;
    public ItemInfo(GameObject _itemObj,string _itemName, string _itemCode)
    {
        itemObj = _itemObj;
        itemName = _itemName;
        itemCode = _itemCode; 
    }

    public string checkItemType()
    {
        switch (itemCode.Substring(0, itemCode.IndexOf("_")))
        {
            case "1":
                maxAmount = 10;
                itemType = "����";
                break;
            case "2":
                maxAmount = 1;
                itemType = "����Ʈ������";
                break;
            case null:
                maxAmount = 1;
                itemType = "��Ÿ ������";
                break;
        }
        return itemType;
    }

    public int SetItemAmount()
    {
        itemAmount = Random.Range(1, maxAmount);

        return itemAmount;
    }


}
