using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    int spawnCount;
    // 최대 몬스터 생성 수
    int MaxEnemy = 100;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        spawnCount = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length -1);
        
        if (timer > spawnData[level].spawnTime && GameManager.instance.Dead == false && spawnCount < MaxEnemy)
        {
            Spawn();
            spawnCount++;
            timer = 0;
        }

    }
     
    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
    public float atk;
    public float exp;
}
