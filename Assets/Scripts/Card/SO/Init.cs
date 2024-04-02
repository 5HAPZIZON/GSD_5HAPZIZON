using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public ItemSO itemSO;
    public EnemySO enemySO;
    public InitSO initSO;
    void Start()
    {
        itemSO.items = initSO.items;
        enemySO.enemies = initSO.enemies;
    }
}

