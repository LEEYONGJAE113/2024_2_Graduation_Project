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
    public QuestManager questManager;
    
    [Header("# Player Stats ")]
    public float playerMaxHP;
    public float playerMoveSpeed;
    public float playerDamage;
    public float playerHPRegen;
    public float playerCooldown;
    public float playerProjectileSpeed;
    public float playerGetRangeRad;

    
    [Header("# In Game Data ")]
    [SerializeField]
    private float _inGameCurrentHp;
    public float inGameCurrentHp
    {
        get => _inGameCurrentHp;
        set => _inGameCurrentHp = Mathf.Clamp(value, 0, playerMaxHP);
    }
    public int inGameLevel;
    public int inGameKill;
    public int inGameGold;

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
        if (questManager.currentQuest == QuestManager.Quests.Survive)
        {
            questManager.questProgress += Time.deltaTime;
        }
    }

    public void Resume()
    {
        isTimeGoing = true;
        Time.timeScale = 1;
    }


    public void LevelUp()
    {
        questManager.GetQuest(++inGameLevel);
    }

}
