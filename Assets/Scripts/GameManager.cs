using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Time Control ")]
    public bool isTimeGoing;
    public float currentGameTime;
    public float maxGameTime;

    [Header("# Objects ")]
    public Player player;
    public PoolManager pool;
    
    [Header("# Player Stats ")]
    public float playerMaxHP;
    public float playerMoveSpeed;
    public float playerDamage;
    public float playerHPRegen;
    public float playerCooldown;
    public float playerProjectileSpeed;
    public float playerGetRangeRad;

    
    [Header("# In Game Data ")]
    public float inGameCurrentHp;
    public int inGameLevel;
    public int inGameKill;
    public int[] QuestKilltemp = { 2, 10, 20, 30, 40, 50 };

    void Awake()
    {
        if (instance == null) { instance = this; }
    }
    
    public void GameStart()
    {
        inGameCurrentHp = playerMaxHP;
        Resume();
    }

    void Update()
    {
        if (!isTimeGoing) { return; }
        
        currentGameTime += Time.deltaTime;
    }

    public void Resume()
    {
        isTimeGoing = true;
        Time.timeScale = 1;
    }

    public void LevelUpTemp()
    {
        if (!isTimeGoing) { return; }

        if (inGameKill == QuestKilltemp[Mathf.Min(inGameLevel, QuestKilltemp.Length-1)])
        {
            inGameLevel++;
        }
    }

}
