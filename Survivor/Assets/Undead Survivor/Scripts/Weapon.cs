using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id; // π´±‚ id
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    private float timer;

    void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            case 1:
                {
                    timer += Time.deltaTime;

                    if (timer > speed)
                    {
                        timer = 0.0f;
                        Fire();
                    }
                    break;
                }
            default:
                break;
        }

        // prefabId = GameManager.instance.
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150; // Ω√∞Ë π›¥Î πÊ«‚¿∏∑Œ »∏¿¸ º”µµ
                Batch();
                break;
            case 1:
                speed = 0.5f;
                break;
            default:
                break;
        }
    }

  
    void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;

            bullet.transform.position = new Vector3(0, 0, 0);
            bullet.parent = transform; // ∫Œ∏∏¶ πŸ≤ﬁ
            
            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);

            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity Per.
        }
    }
    
    /*
    void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Transform bullet;

            if (index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform; // ÔøΩŒ∏ÔøΩ ÔøΩŸ≤ÔøΩ
            }

            bullet.transform.position = new Vector3(0, 0, 0);

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);

            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity Per.
        }
    }*/

    void Fire()
    {
        Debug.Log("111111");
        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.transform.position = new Vector3(0, 0, 0); /*transform.position;*/
        bullet.parent = transform;
    }
}
