using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int _id;
    // { 원거리추적무기 }
    [SerializeField]
    private int _prefabsId;
    [SerializeField]
    private int _count; // penetr in bullet
    [SerializeField]
    private float _cooldown;

    private float _timer;

    public float damage;
    private Player _player;


    void Awake()
    {
        _player = GameManager.instance.player;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _cooldown)
        {
            _timer = 0f;
            FireBullet();
        }
    }

    public void Init()
    {
        transform.parent = _player.transform;
        transform.localPosition = Vector3.zero;
    }

    void FireBullet()
    {
        if (!_player.scanner.nearestTarget) { return; }

        Vector3 targetPos = _player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        // Get(temp), need item data-prefabId
        Transform bullet = GameManager.instance.pool.Get(1).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, _count, dir);
        // need getcomponent
    }

}
