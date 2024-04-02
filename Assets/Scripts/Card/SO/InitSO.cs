using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InitSO", menuName = "Scriptable Object/InitSO")]
public class InitSO : ScriptableObject
{
    public Item[] items;
    public Enemy[] enemies;
}
