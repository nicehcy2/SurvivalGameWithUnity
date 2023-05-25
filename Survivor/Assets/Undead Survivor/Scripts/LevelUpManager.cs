using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    int enumSize = 4;
    int[] arr;

    public List<Sprite> skillSprite;
    public GameObject levelUpUI;
    enum upgrade {
        skillDamage = 0, skillCount, health, speed
    }

    public void selectUpgrade()
    {
        int random = Random.Range(0, enumSize - 1);
        arr = new int[3];
        int cnt = 0;

        for (int i = 0; i < enumSize; i++) 
        {
            if (i == random) continue;

            arr[cnt] = i;
            gameObject.transform.GetChild(cnt).GetChild(1).GetComponent<Image>().sprite = skillSprite[i];
            cnt++;
        }

    }

    public void upgradeSkillDamage()
    {
    }

    public void upgradeCount()
    {   /*
        int cnt = GameManager.instance.player.transform.GetChild(3).GetComponent<Weapon>().count + 2;
        float damage = GameManager.instance.player.transform.GetChild(3).GetComponent<Weapon>().damage;
        float speed = GameManager.instance.player.transform.GetChild(3).GetComponent<Weapon>().speed;
        GameManager.instance.player.transform.GetChild(3).GetComponent<Weapon>().ReInit(0, 1, 10f, 10, 150);
        GameManager.instance.player.transform.GetChild(5).GetComponent<Weapon>().count += 2;
        */
    }
    public void upgradeHealth()
    {
        GameManager.instance.player.maxHealth += 5;
    }

    public void upgradeSpeed()
    {
        GameManager.instance.player.speed++;
        GameManager.instance.player.curSpeed++;
    }

    public void Select1()
    {
        if (GameManager.instance.levelUpActive)
        {   
            if (arr[0] == 0)
            {
                upgradeSkillDamage();
            }
            else if (arr[0] == 1)
            {
                upgradeCount();
            }
            else if (arr[0] == 2)
            {
                upgradeHealth();
            }
            else if (arr[0] == 3)
            {
                upgradeSpeed();
            }


            GameManager.instance.levelUpActive = false;
            levelUpUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
    }

    public void Select2()
    {
        if (arr[1] == 0)
        {
            upgradeSkillDamage();
        }
        else if (arr[1] == 1)
        {
            upgradeCount();
        }
        else if (arr[1] == 2)
        {
            upgradeHealth();
        }
        else if (arr[1] == 3)
        {
            upgradeSpeed();
        }

        if (GameManager.instance.levelUpActive)
        {
            GameManager.instance.levelUpActive = false;
            levelUpUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
    }

    public void Select3()
    {
        if (arr[2] == 0)
        {
            upgradeSkillDamage();
        }
        else if (arr[2] == 1)
        {
            upgradeCount();
        }
        else if (arr[2] == 2)
        {
            upgradeHealth();
        }
        else if (arr[2] == 3)
        {
            upgradeSpeed();
        }

        if (GameManager.instance.levelUpActive)
        {
            GameManager.instance.levelUpActive = false;
            levelUpUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
    }

}
