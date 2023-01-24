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

    public PoolManager pool;
    public Player player;
    public GameObject gameoverUI;
    public GameObject pauseUI;

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
        }
        else
        {
            if (!pauseActive)
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
}
