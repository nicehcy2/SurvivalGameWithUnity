using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Text[] text_lv;
    Player player;
    public int level;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.pauseActive)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            level = player.level;
            text_lv[0].text = level.ToString();
        }
    }
}
