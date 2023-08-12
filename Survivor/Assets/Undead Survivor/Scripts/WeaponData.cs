using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "scriptble Object/WeaponData")]
public class WeaponData : ScriptableObject
{   
    public enum ItemType { Melee, Range, Glove, Shoe, Heal }

    [Header("# Main Info")]
    public ItemType itmeType;
    public int itemId;
    public string itemName;
    public string itemNDesc;
    public string itemIcon;


    [Header("# Level Data")]
    public float BaseDamage;
    public int baseCount;
    public float[] damages;
    public int[] counts;

    [Header("# Weapon")]
    public GameObject projectile;
}
