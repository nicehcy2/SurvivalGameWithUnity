using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    // �̱������� ����
    public static GameManager instance;

    public float gameTime;
    public float MaxGameTime;
    public bool Dead = false;
    public bool pauseActive = false;
    public bool levelUpActive = false;
    public int enemyCount = 0;

    public PoolManager pool;
    public Player player;
    public GameObject gameoverUI;
    public GameObject pauseUI;
    public GameObject levelUpUI;
    public GameObject SkillUI;

    public GameObject playerObject;
    public GameObject rangedWeapon;

    void Awake()
    {   if (instance == null)
        {
            instance = this;
            // ���� ���� ���� pause Canvas�� ��Ȱ��ȭ �������Ƿ� �������
            pauseActive = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (player.curHealth <= 0)
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
    }

    public void OnPlayerDead()
    {
        Dead = true;
        gameoverUI.SetActive(true);
        player.curHealth = 0.1f;
        AudioManager.instance.PlayBgm(false);

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
        AudioManager.instance.PlayBgm(true);
    }

    public void Pause()
    {
        pauseActive = true;
        pauseUI.SetActive(true);
        AudioManager.instance.EffectBgm(true);
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
            rangedWeapon.SetActive(true); // ��ų�� �����ϰ� weapon ����
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
            playerObject.SetActive(true); // ��ų�� �����ϰ� weapon ����
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
            // playerObject.SetActive(true); // ��ų�� �����ϰ� weapon ���� 
            SkillUI.SetActive(false);
            AudioManager.instance.EffectBgm(false);
        }
    }
}
