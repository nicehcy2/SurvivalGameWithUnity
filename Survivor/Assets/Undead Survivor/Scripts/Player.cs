using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public int level;
    public int exp;
    private int lateLevel;

    public float curHealth;
    public float maxHealth = 20;

    public HealthBar healthBar;
    public ExpBar expBar;
    // public Inventory inventory;

    Rigidbody2D rigid;
    SpriteRenderer sprite;

    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        speed = 5;
        level = 1;
        lateLevel = level;
        curHealth = maxHealth;
        exp = 0;
        // inventory = GameObject.Find("InventoryPanel");
    }

    private void Update()
    {
        if (level > lateLevel)
        {
            lateLevel++;
            GameManager.instance.levelUpActive = true;
            GameManager.instance.levelUp();
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
    }

    void FixedUpdate()
    {
        // 위치 이동(순간 이동)
        if (!GameManager.instance.Dead && !GameManager.instance.pauseActive && !GameManager.instance.levelUpActive)
        {
            Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
        }
        else
        {
            Vector2 nextVec = Vector2.zero;
            rigid.MovePosition(rigid.position);
        }
    }
    private void OnMove(InputValue value)
    {
        if (!GameManager.instance.Dead && !GameManager.instance.pauseActive && !GameManager.instance.levelUpActive)
            inputVec = value.Get<Vector2>();
        else
        {
            inputVec = Vector2.zero;
        }
    }

    private void LateUpdate()
    {
        anim.SetFloat("speed", inputVec.magnitude);
        
        if (GameManager.instance.Dead) {
            anim.SetTrigger("dead");

            for (int i = 2; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        

        if (inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
    }


    // 임시
    public void DamagePlayer(float damage)
    {
        curHealth -= Time.deltaTime * damage;

        healthBar.SetHealth(curHealth);
    }

    public void HealPlayer(float heal)
    {
        curHealth += heal;

        healthBar.SetHealth(curHealth);
    }

    public void setPlayerExp()
    {
        exp++;
        expBar.SetExpBar(exp);
    }

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            GameManager.instance.player.HealPlayer(5.0f);

            // if (inventory.GetComponent<Inventory>().AddItem()) Destroy(gameObject);
            if (inventory.AddItem()) DestoryItem();
        }
    }*/
}
