using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies;
    [SerializeField]
    private Transform[] _spawnPoint;

    [SerializeField]
    private float _spawnInterval = 5f;

    private float timer;

    void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
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
        Instantiate(_enemies[0]);
        _enemies[0].transform.position = _spawnPoint[0].position;
        _enemies[0].GetComponent<Enemy>().Init(); 
    }

}