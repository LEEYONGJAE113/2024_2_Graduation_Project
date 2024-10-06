using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies;

    [SerializeField]
    private float _spawnInterval = 5f;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(_enemies[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

}