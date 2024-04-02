using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer card;
    [SerializeField] TMP_Text costTMP;
    public Item item;
    public PRS originPRS;

    public void Setup(Item item){
        this.item = item;

        card.sprite = this.item.sprite;
        costTMP.text = this.item.cost.ToString();
    }

    void OnMouseOver(){
        CardManager.Inst.CardMouseOver(this);
    }

    void OnMouseExit(){
        CardManager.Inst.CardMouseExit(this);
    }

    void OnMouseDown(){
        CardManager.Inst.CardMouseDown();
    }

    void OnMouseUp(){
        CardManager.Inst.CardMouseUp();
    }

    public void MoveTransform(PRS prs, bool useDotween, float dotweenTime = 0){
        if(useDotween){
            transform.DOMove(prs.pos, dotweenTime);
            transform.DORotateQuaternion(prs.rot, dotweenTime);
        }
        else{
            transform.position = prs.pos;
            transform.rotation = prs.rot;
        }
    }

}
