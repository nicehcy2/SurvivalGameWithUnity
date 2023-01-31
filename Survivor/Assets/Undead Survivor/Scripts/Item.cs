using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // public string type;
    Rigidbody2D rigid;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector3.zero;
        healthBar = GetComponent<HealthBar>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.player.HealPlayer(5.0f);
            Destroy(gameObject);
        }
    }
}