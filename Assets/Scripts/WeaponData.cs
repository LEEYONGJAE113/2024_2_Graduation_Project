using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    public enum WeaponType { Bullet, Meteor }

    [Header("# Info")]
    public WeaponType weaponType;
    public int weaponId;
    public string weaponName;
    public Sprite weaponIcon;
    [TextArea]
    public string weaponDesc;
    public GameObject projectile; // for prefabs
    [Header("# Level Data")]
    public float baseDamage;
    public float baseCooldown;
    public int baseCount;

    public float[] damages;
    public float[] cooldowns;
    public int[] counts;
}
