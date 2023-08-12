using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id; // ���� id
    public int prefabId;
    public float damage = 10;
    public int count;
    public float speed;

    private float timer;
    Player player;

    private void Awake()
    {
        player = GameManager.instance.player;
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

                    if (timer > speed / count) 
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

    public void Init(WeaponData data)
    {
        // Basic Set
        name = "Weapon " + data.itemId;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        // Property Set
        id = data.itemId;
        damage = data.BaseDamage;
        count = data.baseCount;

        if (id == 0)
            prefabId = 1;
        else if (id == 1)
            prefabId = 3;

        /*
        for (int i = 0; i < GameManager.instance.pool.prefabs.Length; i++)
        {
            if (data.projectile == GameManager.instance.pool.prefabs[i])
            {
                prefabId = i;
                break;
            }
        }*/

        switch (id)
        {
            case 0:
                speed = 150; // �ð� �ݴ� �������� ȸ�� �ӵ�;
                Batch();
                break;
            case 1:
                speed = 0.5f;   
                break;
            default:
                break;
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count = count;

        if (id == 0)
        {
            Batch();
            Debug.Log("ID == 0");
        }
    }

    public void Batch()
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
                bullet = GameManager.instance.pool.Get(prefabId ).transform;
                bullet.parent = transform; // �θ� �ٲ�
            }

            bullet.parent = transform; // �θ� �ٲ�
            bullet.transform.localPosition = new Vector3(0, 0, 0);

           
            //bullet.transform.localPosition = new Vector3(0, 0, 0);
            //bullet.parent = transform; // �θ� �ٲ�

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);

            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); // -1 is Infinity Per.
        }
    }
   

    void Fire()
    {
        //if (!GameManager.instance.pauseActive && !GameManager.instance.levelUpActive && !GameManager.instance.Dead)
        {
            if (!player.scanner.nearestTarget)
                return;

            Vector3 targetPos = player.scanner.nearestTarget.position;
            Vector3 dir = targetPos - transform.position;
            dir = dir.normalized;

            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.position = transform.position; // ��ġ
            bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir); // ȸ��
            bullet.GetComponent<Bullet>().Init(damage, count, dir);
            bullet.parent = transform;
        }
    }
}
