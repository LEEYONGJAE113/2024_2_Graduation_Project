using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Objects ")]
    public Player player;
    public PoolManager pool;
    
    [Header("# Player ")]
    public float playerCurrentHP;
    public float playerMaxHP;
    public float playerEXP;
    public int playerLevel;
    public float playerMoveSpeed;
    public int kill;

    

    void Awake()
    {
        instance = this;
    }
    
    void GameStart()
    {
        playerCurrentHP = playerMaxHP;
    }
}
