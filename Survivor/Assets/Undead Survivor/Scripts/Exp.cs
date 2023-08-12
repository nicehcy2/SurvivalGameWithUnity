using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public string type;
    Rigidbody2D rigid;

    public bool magnetTime;

    // Start is called before the first frame update
    void Awake()
    {   
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector3.zero;
        magnetTime = false;
        Invoke("FalseEXP", 20.0f);
    }

    private void Update()
    {
        if (magnetTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, 0.015f);
        }
    }

    private void OnEnable()
    {
        magnetTime = false;
    }

    public void FalseEXP()
    {
        gameObject.SetActive(false);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.player.setPlayerExp();
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
            gameObject.SetActive(false);
        }
    }
}
