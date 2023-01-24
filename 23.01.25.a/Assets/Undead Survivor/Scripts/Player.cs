using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public float level;

    public float curHealth;
    public float maxHealth = 20;

    public HealthBar healthBar;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        speed = 5;
        level = 1;
        curHealth = maxHealth;
    }

    void FixedUpdate()
    {
        // 위치 이동(순간 이동)
        if (!GameManager.instance.Dead || !GameManager.instance.pauseActive)
        {
            Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
        }
        else
        {
            rigid.MovePosition(rigid.position);
        }
    }

    
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    // 임시
    public void DamagePlayer(float damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
}
