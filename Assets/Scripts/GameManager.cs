using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Time Control ")]
    public bool isTimeGoing;
    public float gameTime;
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

    
    [Header("# In Game Data ")]
    public float inGameCurrentHp;
    public float inGameExp;
    public int inGameLevel;
    public int inGameKill;

    void Awake()
    {
        instance = this;
    }
    
    void GameStart()
    {
        inGameCurrentHp = playerMaxHP;
    }
}
