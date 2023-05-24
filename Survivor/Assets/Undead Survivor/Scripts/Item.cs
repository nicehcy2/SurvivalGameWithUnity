using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // public string type;
    Rigidbody2D rigid;

    private HealthBar healthBar;

    public GameObject inventory;

    public enum ItemType { HealthPack = 0, Mag, Adrenaline, Bomb, Boost }

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector3.zero;
        healthBar = GetComponent<HealthBar>();
        inventory = GameObject.Find("InventoryPanel");
    }

    public void DestoryItem()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "HealthPack(Clone)")
            {
                if (inventory.GetComponent<Inventory>().AddItem(0)) Destroy(gameObject);
            }
            if (gameObject.name == "Mag(Clone)")
            {
                if (inventory.GetComponent<Inventory>().AddItem(1)) Destroy(gameObject);
            }
            if (gameObject.name == "Adrenaline(Clone)")
            {
                if (inventory.GetComponent<Inventory>().AddItem(2)) Destroy(gameObject);
            }
            if (gameObject.name == "Bomb(Clone)")
            {
                if (inventory.GetComponent<Inventory>().AddItem(3)) Destroy(gameObject);
            }
            if (gameObject.name == "Boost(Clone)")
            {
                if (inventory.GetComponent<Inventory>().AddItem(4)) Destroy(gameObject);
            }
        }
    }

}