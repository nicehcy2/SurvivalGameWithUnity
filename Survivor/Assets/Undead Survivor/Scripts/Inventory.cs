using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;

    public List<int> items;


    public int maxSlot = 2;
    public int itemIdx = 0;

    public void AddItem()
    {
        if (items.Count < maxSlot)
        {
            items.Add(itemIdx);
            AddImage(itemIdx++);
            // FreshSlot();
        }
    }

    private void AddImage(int cnt)
    {
        // 해당하는 슬롯 창의 자식 이미지를 활성화
        gameObject.transform.GetChild(cnt).GetChild(0).gameObject.SetActive(true);
    }

    public void DeleteItem0()
    {
        Debug.Log("Delete0");
        gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        items.RemoveAt(0);
        itemIdx = 0;
    }
    public void DeleteItem1()
    {
        Debug.Log("Delete1");
        gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        items.RemoveAt(1);
        itemIdx = 1;
    }
}

