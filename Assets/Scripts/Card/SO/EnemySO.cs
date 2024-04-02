using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy{
    public string name;
    public int attack;
    public int health;
    public GameObject prefabs;
    public float percent;
}

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Object/EnemySO")]
public class EnemySO : ScriptableObject
{
    public Enemy[] enemies;
}
