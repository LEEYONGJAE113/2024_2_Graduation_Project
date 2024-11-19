using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropItem", menuName = "Scriptable Object/DropItemData")]
public class DropItemData : ScriptableObject
{
    public enum DropItemType { Heal, LevelUp, SuperMode, Meteor, Gold }

    [Header("# Info")]
    public DropItemType dropItemType;
    public int dropItemId;
    public GameObject dropItemPrefabs;
    public string dropItemDesc;

    // [Header("# UI")]
    // public string dropItemName;
    // public Sprite dropItemIcon;
}
