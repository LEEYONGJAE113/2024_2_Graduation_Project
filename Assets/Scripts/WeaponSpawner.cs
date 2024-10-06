using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _weapons;

    [SerializeField]
    private float _spawnInterval = 5f;

    void Start()
    {
        StartCoroutine(SpawnWeapons());
    }

    
    void Update()
    {
        
    }

    IEnumerator SpawnWeapons()
    {
        while (true)
        {
            Instantiate(_weapons[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
