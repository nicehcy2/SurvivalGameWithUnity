using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    Slider slider;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        enemy = GameManager.instance.boss;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemy.health / GameManager.instance.maxBossHealth;
        
    }
}
