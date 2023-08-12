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
    public WeaponData data0;
    public WeaponData data1;
    public Weapon weapon;

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
        if (GameManager.instance.meleeWeaponActive)
        {
            float nextDamage = data0.BaseDamage;
            int nextCount = 0;

            nextDamage += data0.BaseDamage * data0.damages[GameManager.instance.weaponDamageCount];
            nextCount = data0.counts[GameManager.instance.weaponCount];
            GameManager.instance.weaponDamageCount++;

            GameManager.instance.meleeWeapon.LevelUp(nextDamage, nextCount);
        }
        else if (GameManager.instance.rangeWeaponActive)
        {
            float nextDamage = data1.BaseDamage;
            int nextCount = 0;

            nextDamage += data1.BaseDamage * data1.damages[GameManager.instance.weaponDamageCount];
            nextCount = data1.counts[GameManager.instance.weaponCount];
            GameManager.instance.weaponDamageCount++;

            GameManager.instance.rangeWeapon.LevelUp(nextDamage, nextCount);
        }
    }

    public void upgradeCount()
    {
        if (GameManager.instance.meleeWeaponActive)
        {
            if (GameManager.instance.weaponLevelCount == 0)
            {
                GameObject newWeapon = new GameObject();
                weapon = newWeapon.AddComponent<Weapon>();
                weapon.Init(data0);
                GameManager.instance.weaponLevelCount++;
            }
            else
            {
                float nextDamage = data0.BaseDamage;
                int nextCount = 0;

                nextCount += data0.counts[GameManager.instance.weaponCount];
                nextDamage += data0.BaseDamage * data0.damages[GameManager.instance.weaponDamageCount];
                GameManager.instance.weaponCount++;

                GameManager.instance.meleeWeapon.LevelUp(nextDamage, nextCount);
            }
        }
        else if (GameManager.instance.rangeWeaponActive)
        {
            if (GameManager.instance.weaponLevelCount == 0)
            {
                GameObject newWeapon = new GameObject();
                weapon = newWeapon.AddComponent<Weapon>();
                weapon.Init(data1);
                GameManager.instance.weaponLevelCount++;
            }
            else
            {
                float nextDamage = data1.BaseDamage;
                int nextCount = 0;

                nextCount += data1.counts[GameManager.instance.weaponCount];
                nextDamage += data1.BaseDamage * data1.damages[GameManager.instance.weaponDamageCount];
                GameManager.instance.weaponCount++;

                GameManager.instance.rangeWeapon.LevelUp(nextDamage, nextCount);
            }
        }
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
