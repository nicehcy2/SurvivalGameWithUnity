using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // public string type;
    Rigidbody2D rigid;

    private HealthBar healthBar;

    public GameObject inventory;

    public enum ItemType { HealthPack = 0 }

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector3.zero;
        healthBar = GetComponent<HealthBar>();
        inventory = GameObject.Find("InventoryPanel");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.player.HealPlayer(5.0f);

            inventory.GetComponent<Inventory>().AddItem();
            // Debug.Log("Item");

            Destroy(gameObject);
        }
    }
}