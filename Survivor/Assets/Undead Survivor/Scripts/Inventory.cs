using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemType> items;



    void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {   
        /*
        for (int i = 0; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
        */
    }

    public void AddItem(ItemType _item)
    {   
        /*
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }*/
    }
}