using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    
    int level;
    // 최대 몬스터 생성 수
    int MaxEnemy = 500;

    // 몬스터의 스폰 시기를 계산하기 위한 변수
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        // 몬스터 소환 level을 적용
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 30f), spawnData.Length -1);
        
        if (timer > spawnData[level].spawnTime && GameManager.instance.Dead == false && GameManager.instance.enemyCount < MaxEnemy)
        {
            if (GameManager.instance.pauseActive == false && GameManager.instance.levelUpActive == false)
            {
                Spawn();
                timer = 0;
            }
        }

    }
     
    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
        GameManager.instance.enemyCount++;
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
