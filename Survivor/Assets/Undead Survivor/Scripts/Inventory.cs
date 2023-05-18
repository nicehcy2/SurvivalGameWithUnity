using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // public GameObject inventory;
    
    public List<Sprite> itemSprite;

    public int[] items;

    public int maxSlot = 2;
    private int itemIdx = 0;
    private int itemCount = 0;

    public void Start()
    {   
        items = new int[maxSlot];
        items[0] = -1;
        items[1] = -1;
    }

    public bool AddItem(int iNum)
    {
        if (itemCount < maxSlot)
        {
            if (iNum == 0) // HealthPack
            {
                items[itemIdx] = (iNum);
                itemCount++;
                AddImage(itemIdx++, iNum);
            }
            if (iNum == 1) // Mag
            {
                items[itemIdx] = (iNum);
                itemCount++;
                AddImage(itemIdx++, iNum);
            }
            if (iNum == 2) // Adrenaline
            {
                items[itemIdx] = (iNum);
                itemCount++;
                AddImage(itemIdx++, iNum);
            }
            if (iNum == 3) // Adrenaline
            {
                items[itemIdx] = (iNum);
                itemCount++;
                AddImage(itemIdx++, iNum);
            }
            return true;
        }
        else
        {
            Debug.Log("Item Add exception");
            return false;
        }
    }

    private void AddImage(int cnt, int iNum)
    {
        // 해당하는 슬롯 창의 자식 이미지를 활성화
        gameObject.transform.GetChild(cnt).GetChild(0).gameObject.SetActive(true);
        if (iNum == 0)
            gameObject.transform.GetChild(cnt).GetChild(0).GetComponent<Image>().sprite = itemSprite[0];
        else if (iNum == 1)
            gameObject.transform.GetChild(cnt).GetChild(0).GetComponent<Image>().sprite = itemSprite[1];
        else if (iNum == 2)
            gameObject.transform.GetChild(cnt).GetChild(0).GetComponent<Image>().sprite = itemSprite[2];
        else if (iNum == 3)
            gameObject.transform.GetChild(cnt).GetChild(0).GetComponent<Image>().sprite = itemSprite[3];
    }

    public void DeleteItem0()
    {
        if (items[0] == 0)
        {
            GameManager.instance.player.HealPlayer(5.0f);
        }
        else if (items[0] == 1)
        {
            GameManager.instance.player.setActiveMag();
        }
        else if (items[0] == 2)
        {
            GameManager.instance.player.setActiveAdrenaline();
        }
        else if (items[0] == 3)
        {
            GameManager.instance.player.setActiveBomb();
        }
        gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        items[0] = -1;
        itemCount--;
        itemIdx = 0;
    }
    public void DeleteItem1()
    {
        if (items[1] == 0)
        {
            GameManager.instance.player.HealPlayer(5.0f);
        }
        else if (items[1] == 1)
        {
            GameManager.instance.player.setActiveMag();
        }
        else if (items[1] == 2)
        {
            GameManager.instance.player.setActiveAdrenaline();
        }
        else if (items[1] == 3)
        {
            GameManager.instance.player.setActiveBomb();
        }
        gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        items[1] = -1;
        itemCount--;

        if (items[0] == -1) itemIdx = 0;
        else itemIdx = 1;
    }
}

