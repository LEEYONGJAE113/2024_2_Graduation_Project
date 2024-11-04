using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary> <item> <description> 0 = 원거리추적무기, </description> </item> </summary>
    [SerializeField]
    private int _id;
    public float damage;
    [SerializeField]
    private int _count; // penetr in bullet
    [SerializeField]
    private float _cooldown;
    private float _timer;
    private Player _player;


    void Awake()
    {
        _player = GameManager.instance.player;
    }

    public void Init(WeaponData data)
    {
        name = "Weapon " + data.weaponId + " : " + data.weaponName; //object name

        transform.parent = _player.transform;
        transform.localPosition = Vector3.zero;

        PropertySet(data);
    }
    
    void PropertySet(WeaponData data)
    {
        _id = data.weaponId;
        damage = data.baseDamage;
        _count = data.baseCount;
        _cooldown = data.baseCooldown;
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


    void FireBullet()
    {
        if (!_player.scanner.nearestTarget) { return; }

        Vector3 targetPos = _player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.instance.pool.Get(1, _id).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, _count, dir);
    }
}