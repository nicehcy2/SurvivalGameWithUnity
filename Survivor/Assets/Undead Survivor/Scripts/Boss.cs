using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    // Start is called before the first frame update

    Enemy boss;

    public float _SmashDelayTime;
    void Start()
    { 
        boss.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        _SmashDelayTime += Time.deltaTime;
        if (_SmashDelayTime % 3 < 1)
        {
            boss.boost(100.0f);
            /*boss1.speed = 100.0f;*/
            /*boss1.GetComponent<Enemy>().Init(GetComponent<Spawner>().spawnData[2]);*/
            _SmashDelayTime = 0f;

        }
        else if (_SmashDelayTime % 2 < 0)
        {
            /*boss1.GetComponent<Enemy>().Init(GetComponent<Spawner>().spawnData[1]);*/
            boss.boost(5.0f);

        }
    }
}
