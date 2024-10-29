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

    [SerializeField]
    private float _spawnInterval = 5f;

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
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = _spawnPoints[Random.Range(1, _spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init();
    }

}