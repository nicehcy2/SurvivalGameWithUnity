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
    public float MaxGameTime = 0.3f * 60f;
    public bool Dead = false;
    public bool pauseActive = false;
    public bool levelUpActive = false;

    public PoolManager pool;
    public Player player;
    public GameObject gameoverUI;
    public GameObject pauseUI;
    public GameObject levelUpUI;

    void Awake()
    {   if (instance == null)
        {
            instance = this;
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
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        pauseActive = true;
        pauseUI.SetActive(true);
    }

    public void Resume()
    {
        pauseActive = false;
        pauseUI.SetActive(false);
    }

    public void levelUp()
    {
        levelUpUI.SetActive(true);
    }

    public void Select1()
    {
        levelUpActive = false;
        levelUpUI.SetActive(false);
    }

    public void Select2()
    {
        levelUpActive = false;
        levelUpUI.SetActive(false);
    }

    public void Select3()
    {
        levelUpActive = false;
        levelUpUI.SetActive(false);
    }
}