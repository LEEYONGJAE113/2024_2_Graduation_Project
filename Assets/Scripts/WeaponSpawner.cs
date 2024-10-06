using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;

    [SerializeField]
    private float spawnInterval = 5f;

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
            Instantiate(weapons[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
