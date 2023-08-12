using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    // 싱글턴으로 구현
    public static GameManager instance;

    public float gameTime;
    public float MaxGameTime;
    public bool Dead = false;
    public bool pauseActive = false;
    public bool levelUpActive = false;
    public int enemyCount = 0;
    public int weaponCount = 0;
    public int weaponDamageCount = 0;
    public int weaponLevelCount = 0;
    public int bossHealth = 0;
    public int bossCount = 0;
    public int maxBossHealth = 1000;

    public PoolManager pool;
    public Player player;
    public GameObject gameoverUI;
    public GameObject pauseUI;
    public GameObject optionUI;
    public GameObject levelUpUI;
    public GameObject SkillUI;
    public GameObject gameclearUI;
    public Boss boss_start;
    public Enemy boss;
    public bool bossActive = false;
    public float Delay = 0.0f;

    public GameObject playerObject;
    public GameObject rangedWeapon;
    public Weapon meleeWeapon;
    public bool meleeWeaponActive = false;
    public Weapon rangeWeapon;
    public bool rangeWeaponActive = false;
    public GameObject bossHealthBar;

    public Scrollbar BGMScrollbar;
    public Scrollbar SFXScrollbar;

    public WeaponData data0;
    public WeaponData data1;

    void Awake()
    {   if (instance == null)
        {
            instance = this;
            // 게임 시작 전엔 pause Canvas가 비활성화 돼있으므로 상관없음
            pauseActive = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update() { 
        if (player.curHealth <= 0 || gameTime > 60 * 60f)
        {
            OnPlayerDead();
            gameTime = 0;
        }
        else
        {
            if (!pauseActive && !levelUpActive)
            {
                gameTime += Time.deltaTime;

                if (gameTime > MaxGameTime)
                {
                    gameTime = MaxGameTime;
                }
            }
        }

        if (player.level >= 11 && bossCount == 0)
        {
            boss_start.gameObject.SetActive(true);
            bossHealthBar.SetActive(true);
            bossActive = true;
            bossCount++;
            if (Delay % 2 > 1)
            {
                boss.boost(10.0f);

            }
            else if (Delay % 2.5 > 1)
            {
                Delay = 0.0f;
            }
            else
            {
                boss.boost(2.0f);
            }
        }

        if (boss_start.gameObject.activeSelf == false && player.level >= 11)
        {
            gameClear();
            gameTime = 0;
        }
    }

    public void OnPlayerDead()
    {
        Dead = true;
        gameoverUI.SetActive(true);
        player.curHealth = 0.1f;
        AudioManager.instance.PlayBgm(false);

        if (gameTime != 0f)
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Lose);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameStart()
    {
        SkillUI.SetActive(true);
        // playerSkill0.SetActive(true);
        // AudioManager.instance.bgmPlayer.mute = false;
        AudioManager.instance.PlayBgm(true);
    }

    public void setBGMVolume()
    {
        AudioManager.instance.bgmPlayer.volume = BGMScrollbar.value * 0.2f;
    }

    public void setSFXtVolume()
    {
        for (int i = 0; i < AudioManager.instance.sfxPlayers.Length; i++)
        {
            AudioManager.instance.sfxPlayers[i].volume = SFXScrollbar.value * 0.5f;
        }
    }

    public void Pause()
    {
        pauseActive = true;
        pauseUI.SetActive(true);
        AudioManager.instance.EffectBgm(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitOption()
    {
        optionUI.SetActive(false);
    }

    public void Option()
    {
        optionUI.SetActive(true);
    }

    public void Resume()
    {
        pauseActive = false;
        pauseUI.SetActive(false);
        AudioManager.instance.EffectBgm(false);
    }

    public void levelUp()
    {
        levelUpUI.SetActive(true);
        levelUpUI.GetComponent<LevelUpManager>().selectUpgrade();
        AudioManager.instance.EffectBgm(true);
    }

    public void Select1()
    {
        if (levelUpActive)
        {
            levelUpActive = false;
            levelUpUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
        else
        {
            pauseActive = false;
            rangeWeaponActive = true;
            GameObject newWeapon = new GameObject();
            
            rangeWeapon = newWeapon.AddComponent<Weapon>();
            rangeWeapon.Init(data1);
            GameManager.instance.weaponLevelCount++;

            SkillUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
    }

    public void Select2()
    {
        if (levelUpActive)
        {
            levelUpActive = false;
            levelUpUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
        else
        {
            pauseActive = false;
            meleeWeaponActive = true;
            GameObject newWeapon = new GameObject();
            meleeWeapon = newWeapon.AddComponent<Weapon>();
            
            meleeWeapon.Init(data0);
            GameManager.instance.weaponLevelCount++;

            SkillUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
    }

    public void Select3()
    {
        if (levelUpActive)
        {
            levelUpActive = false;
            levelUpUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
        else
        {
            pauseActive = false;
            // playerObject.SetActive(true); // 스킬을 선택하고 weapon 착용 
            SkillUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
    }

    public void gameClear()
    {
        pauseActive = true;
        pauseUI.SetActive(false);
        gameclearUI.SetActive(true);
        if (gameTime != 0)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Win);
        }
        gameTime = 0;
    }


}
