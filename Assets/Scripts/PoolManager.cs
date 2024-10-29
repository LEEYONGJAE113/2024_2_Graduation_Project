using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    private List<GameObject>[] _pools;

    void Awake()
    {
        _pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < _pools.Length; index++)
        {
            _pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject target in _pools[index])
        {
            if(!target.activeSelf)
            {
                select = target;
                select.SetActive(true);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);
            _pools[index].Add(select);
        }

        return select;

    }
}
