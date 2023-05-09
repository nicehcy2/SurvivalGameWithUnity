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

    private bool isLive;

    Collider2D coll;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait; // 다음 fiexedUpdate가 될 때 까지 쉼

    public RuntimeAnimatorController[] animCon;
    Animator anim;

    // public GameObject expCoin;

    // Start is called before the first frame update
    void Awake()
    {   
        coll = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
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
        health = maxHealth;

        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
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
        StartCoroutine(KnockBack());

        if (health <= 0)
        {   
            EnemyDead();
            Invoke("DropExp", 1.0f);
        }
        else
        {
            anim.SetTrigger("Hit");
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);
        }
    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position; 
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }

    public void DropExp()
    {   
        if (!isLive)
        {   
            int ran = Random.Range(0, 10);
            if (ran < 7)
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
        if (isLive)
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead);
        isLive = false;
        coll.enabled = false;
        rigid.simulated = false;
        spriter.sortingOrder = 1;
        anim.SetBool("Dead", true);

        
        Invoke("FalseActive", 1.0f);
    }

    public void FalseActive()
    {
        gameObject.SetActive(false);

    }
}
