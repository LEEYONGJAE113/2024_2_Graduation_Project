using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public float enemyHealth;
    public float enemyMoveSpeed;
    public int enemyType; // for enemy sprite
}

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spawnPoints;
    public EnemyData[] enemyDatas;

    [SerializeField]
    private float _spawnInterval;

    private float timer;

    void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > _spawnInterval)
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

