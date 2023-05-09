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
    public float MaxGameTime = 0.3f * 60f;
    public bool Dead = false;
    public bool pauseActive = false;
    public bool levelUpActive = false;

    public PoolManager pool;
    public Player player;
    public GameObject gameoverUI;
    public GameObject pauseUI;
    public GameObject levelUpUI;

    public GameObject playerObject;

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
                // gameTime += Time.deltaTime;

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

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Lose);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameStart()
    {
        pauseActive = false;
        playerObject.SetActive(true);
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
        AudioManager.instance.EffectBgm(true);
    }

    public void Select1()
    {
        levelUpActive = false;
        levelUpUI.SetActive(false);
        AudioManager.instance.EffectBgm(false);
    }

    public void Select2()
    {
        levelUpActive = false;
        levelUpUI.SetActive(false);
        AudioManager.instance.EffectBgm(false);
    }

    public void Select3()
    {
        levelUpActive = false;
        levelUpUI.SetActive(false);
        AudioManager.instance.EffectBgm(false);
    }
}
