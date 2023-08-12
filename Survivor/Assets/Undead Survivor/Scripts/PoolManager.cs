using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. ��������� ������ ���� n
    public GameObject[] prefabs;

    // .. Ǯ ����� �ϴ� ����Ʈ�� n
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        
        for(int index =0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>(); 
        }
    }

    public GameObject Get(int index)
    {
        if (GameManager.instance.pauseActive  || GameManager.instance.Dead)
           return null;

        GameObject select = null;

        // ... ������ Ǯ�� ���(��Ȱ��ȭ) �ִ� ���� ������Ʈ ����

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // ... �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ...  �� ã������?      
        if (select == null)
        {
            // ... ���Ӱ� �����ϰ� select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select); 
        }


        return select;
    }
}
