using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Entity : MonoBehaviour
{
    public Item item;
    public Enemy enemy;
    public GameObject thisentity;
    public int attack;
    public int health;
    public bool isAlly;
    public bool isUnit;
    public bool isMagic;
    public bool isTower;
    public bool magicShot;
    public bool isWeapon;
    public Vector3 originPos;

    public void Setup(Item item){
        this.item = item;
        attack = item.attack;
        health = item.health;
        isUnit = item.isUnit;
        isMagic = item.isMagic;
        isTower = item.isTower;
        isAlly = true;
        if(isMagic) magicShot = false;
    }

    public void SetupEnemy(Enemy enemy){
        this.enemy = enemy;
        attack = enemy.attack;
        health = enemy.health;
        isAlly = false;
    }

    public void MoveTransform(Vector3 pos, bool useDotween, float dotweenTime = 0){
        if(useDotween)
            transform.DOMove(pos, dotweenTime);
        else
            transform.position = pos;
    }

}
