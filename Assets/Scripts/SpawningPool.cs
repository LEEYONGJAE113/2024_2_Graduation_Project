using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies;
    [SerializeField]
    private Transform[] _spawnPoints;
    public EnemyData[] enemyDatas;


    private float timer;

    void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > enemyDatas[0].spawnTime) // 0 is temp
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0, 0);
        enemy.transform.position = _spawnPoints[Random.Range(1, _spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init(enemyDatas[0]); // 0 is temp
    }

}

[System.Serializable]
public class EnemyData
{
    public float spawnTime;
    public float enemyHealth;
    public float enemyMoveSpeed;
    public int enemyType; // for enemy sprite
}