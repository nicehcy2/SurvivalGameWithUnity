using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider expBar;
    public Player playerExp;

    public int[] level;
    int cnt_lv;

    private void Start()
    {
        playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        expBar = GetComponent<Slider>();
        expBar.maxValue = level[0];
        cnt_lv = 0;
        expBar.value = playerExp.exp;
    }

    private void Update()
    {   
        if (expBar.value == expBar.maxValue)
        {
            GameManager.instance.player.level++;
            GameManager.instance.player.exp = 0;
            expBar.value = 0;
            expBar.maxValue = level[++cnt_lv];
        }
    }

    public void SetExpBar(float exp)
    {
        expBar.value = exp;
    }
}
