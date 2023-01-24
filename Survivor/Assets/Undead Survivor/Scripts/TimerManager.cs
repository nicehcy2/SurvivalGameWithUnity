using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    bool active;
    public Text[] text_time;
    // public Text bin_text;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime;

            if ((int)time / 60 % 60 < 10)
            {
                text_time[0].text = 0.ToString() + ((int)time / 60 % 60).ToString();
            }
            else
            {
                text_time[0].text = ((int)time / 60 % 60).ToString();
            }

            if ((int)time % 60 < 10)
            {
                text_time[1].text = 0.ToString() + ((int)time % 60).ToString();
            }
            else
            {
                text_time[1].text = ((int)time % 60).ToString();
            }
        }

        if (GameManager.instance.Dead || GameManager.instance.pauseActive)
        {
            active = false;
        }
        else
        {
            active = true;
        }
    }
}
