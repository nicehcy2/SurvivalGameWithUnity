using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public float atk;
    public float exp;
    public int itemPrefabId;

    public Rigidbody2D target;

    public bool isLive;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    // public GameObject expCoin;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLive)
            return;
        if (GameManager.instance.Dead || GameManager.instance.pauseActive || GameManager.instance.levelUpActive)
        {
            rigid.MovePosition(rigid.position);
            return;
        }

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!isLive)
            return;
        if (GameManager.instance.Dead || GameManager.instance.pauseActive || GameManager.instance.levelUpActive)
            return;
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        gameObject.GetComponent<Collider2D>().enabled = true;
        health = maxHealth;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        //부딪힌 객체의 태그를 비교해서 적인지 판단합니다.
        {   
            GameManager.instance.player.DamagePlayer(atk);
        }
    }

    public void Init(SpawnData data)
    {
        //anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
        atk = data.atk;
        exp = data.exp;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        health -= collision.GetComponent<Bullet>().damage;

        if (health <= 0)
        {   
            EnemyDead();
            DropExp();
        }
    }
    public void DropExp()
    {
        if (!isLive)
        {   
            int ran = Random.Range(0, 10);
            if (ran < 8)
            {   
                // Instantiate(expCoin, transform.position, expCoin.transform.rotation);
                Transform exp = GameManager.instance.pool.Get(itemPrefabId).transform;
                exp.transform.position = this.transform.position;
                exp.transform.rotation = this.transform.rotation;
            }
        }
    }

    public void EnemyDead()
    {   
        isLive = false;
        // Enemy 충돌 비활성화 -> reposition 스크립트가 작동안함
        gameObject.GetComponent<Collider2D>().enabled = false;

        gameObject.SetActive(false);
    }
}
