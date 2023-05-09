using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public string type;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Awake()
    {   
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector3.zero;
        Invoke("FalseEXP", 20.0f);
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
