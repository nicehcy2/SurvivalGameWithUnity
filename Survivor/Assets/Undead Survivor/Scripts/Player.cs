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

    private bool adrenalineActive;
    private bool boostActive;

    public float curHealth;
    public float maxHealth = 20;

    public HealthBar healthBar;
    public ExpBar expBar;
    public Magent magnet;
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
        adrenalineActive = false;
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

        if (adrenalineActive)
        {
            curHealth -= 1f * Time.deltaTime;
            speed = 10.0f;
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

    public void setPlayerExp()
    {
        exp++;
        expBar.SetExpBar(exp);
    }

    /* ITEM */

    // Heal
    public void HealPlayer(float heal)
    {
        curHealth += heal;

        healthBar.SetHealth(curHealth);
    }

    public void setActiveMag()
    {
        StartCoroutine(magnetItem());
    }

    IEnumerator magnetItem()
    {
        transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
    }

    public void setActiveAdrenaline()
    {
        StartCoroutine(adrenalineItem());
    }
    IEnumerator adrenalineItem()
    {
        adrenalineActive = true;
        yield return new WaitForSeconds(5f);
        speed = 5;
        adrenalineActive = false;
    }

    public void setActiveBomb()
    {
        transform.GetChild(4).GetChild(1).gameObject.SetActive(true);
        Invoke("setUnActiveBomb", 1.0f);
    }

    public void setUnActiveBomb()
    {
        transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
    }

    public void setBoost()
    {
        StartCoroutine(boostItem());
    }

    IEnumerator boostItem()
    {
        boostActive = true;
        transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
        speed = 8;


        yield return new WaitForSeconds(3.0f);
        speed = 5;
        boostActive = false;
        transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
    }
}
