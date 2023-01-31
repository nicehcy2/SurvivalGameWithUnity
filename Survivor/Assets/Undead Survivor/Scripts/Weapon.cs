using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id; // ���� id
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

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
                speed = 150; // �ð� �ݴ� �������� ȸ�� �ӵ�
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        for (int index =0; index < count; index++)
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.transform.position = new Vector3(0, 0, 0);
            bullet.parent = transform; // �θ� �ٲ�
            
            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);

            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity Per.
        }
    }
}
