using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int cost;
    public int attack;
    public int health;
    public int reinforce;
    public Sprite sprite;
    public GameObject prefabs;
    public float percent;
    public bool isUnit;
    public bool isMagic;
    public bool isTower;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Object/ItemSO")]
public class ItemSO : ScriptableObject
{
    public Item[] items;
}
