using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    public static CardManager Inst{get; private set;}
    void Awake() => Inst = this;

    [SerializeField] ItemSO itemSO;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] GameObject cardArea;
    [SerializeField] List<Card> myCards;
    [SerializeField] Transform cardSpawnPoint;
    [SerializeField] Transform myCardLeft;
    [SerializeField] Transform myCardRight;
    [SerializeField] List<GameObject> myCardObjects;
    [SerializeField] Text costBar;
    List<Item> itemBuffer;
    Card selectCard;
    float selectCardx;
    bool isMyCardDragged;
    bool onMyCardArea;
    bool isAlligning;
    int mycardCount;
    public int myCost;

    public Item popItem(){
        if(itemBuffer.Count == 0)
            SetupItemBuffer();

        Item item = itemBuffer[0];
        itemBuffer.RemoveAt(0);
        return item;
    }

    void SetupItemBuffer(){
        itemBuffer = new List<Item>(100);
        for(int i = 0; i < itemSO.items.Length; ++i){
            Item item = itemSO.items[i];
            for(int j = 0; j < item.percent; ++j)
                itemBuffer.Add(item);
        }

        for(int i = 0; i < itemBuffer.Count; ++i){
            int rand = Random.Range(i, itemBuffer.Count);
            Item tmp = itemBuffer[i];
            itemBuffer[i] = itemBuffer[rand];
            itemBuffer[rand] = tmp;
        }
    }

    void Start(){
        mycardCount = 0;
        myCost = 10;
        SetupItemBuffer();
        StartCoroutine(CostAdd(2f));
    }

    void Update(){
        costBar.text = myCost.ToString();

        isAlligning = false;
        if(mycardCount != 5){
            isAlligning = true;
            mycardCount++;
            AddCard();
        }

        foreach(GameObject cardob in myCardObjects)
            cardob.GetComponent<Card>().originPRS.pos.x = cardob.transform.position.x;
   
        if(isMyCardDragged)
            CardDrag();

        DetectCardArea();
    }

    IEnumerator CostAdd(float waittime){
        yield return new WaitForSecondsRealtime(waittime);
        if(myCost < 20)
            myCost += 1;
        StartCoroutine(CostAdd(1.5f));
    }

    void AddCard(){
        var cardObject = Instantiate(cardPrefab, cardSpawnPoint.position, Utils.QI, GameObject.Find("Main Camera").transform);
        var card = cardObject.GetComponent<Card>();
        card.Setup(popItem());
        myCards.Add(card);
        myCardObjects.Add(cardObject);

        SetOriginOrder();
        CardAlignment();
    }

    void SetOriginOrder(){
        for(int i = 0; i < myCards.Count; ++i)
            myCards[i].GetComponent<Order>().SetOriginOrder(i);
    }

    void CardAlignment(){
        List<PRS> originCardPRSs = new List<PRS>();
        originCardPRSs = RoundAlignment(myCardLeft, myCardRight, myCards.Count, 0.5f, Vector3.one * 1.9f);

        for(int i = 0; i < myCards.Count; ++i){
            myCards[i].originPRS = originCardPRSs[i];
            myCards[i].MoveTransform(myCards[i].originPRS, true, 0.7f);
        }
    }

    List<PRS> RoundAlignment(Transform leftTr, Transform rightTr, int objCount, float height, Vector3 scale){
        float[] objLerps = new float[objCount];
        List<PRS> results = new List<PRS>(objCount);

        switch(objCount){
            case 1: objLerps = new float[] {0.5f}; break;
            case 2: objLerps = new float[] {0.3f, 0.7f}; break;
            case 3: objLerps = new float[] {0.1f, 0.5f, 0.9f}; break;
            default:
                float interval = 1f / (objCount - 1);
                for(int i = 0; i < objCount; ++i)
                    objLerps[i] = interval * i;
                break;
        }
        
        for(int i = 0; i < objCount; ++i){
            var targetPos = Vector3.Lerp(leftTr.position, rightTr.position, objLerps[i]);
            var targetRot = Utils.QI;  
            if(objCount >= 4){
                float curve = Mathf.Sqrt(Mathf.Pow(height, 2) - Mathf.Pow(objLerps[i] - 0.5f, 2));
                curve = height >= 0 ? curve : -curve;
                targetPos.y += curve;
                targetRot = Quaternion.Slerp(leftTr.rotation, rightTr.rotation, objLerps[i]);
            }
            results.Add(new PRS(targetPos, targetRot, scale));
        }
        return results;
    }

    public void TryPutCard(){
        Card card = selectCard;
        var spawnPos = Utils.MousePos;

        EntityManager.Inst.SpawnEntity(card.item, spawnPos);
        myCards.Remove(card);
        myCardObjects.Remove(myCardObjects.Find (x => x.GetComponent<Card>() == card));
        card.transform.DOKill();
        DestroyImmediate(card.gameObject);
        selectCard = null;
        mycardCount--;
        myCost -= card.item.cost;
    }

    #region MyCard

    public void CardMouseOver(Card card){
        selectCard = card;
        if(!isMyCardDragged)
            selectCardx = selectCard.transform.position.x;

        if(!isAlligning)
            EnlargeCard(true, card);
    }

    public void CardMouseExit(Card card){
        EnlargeCard(false, card);
    }

    public void CardMouseDown(){
        isMyCardDragged = true;
    }

    public void CardMouseUp(){
        isMyCardDragged = false;
        Card c = selectCard;

        if(!onMyCardArea && (myCost >= selectCard.item.cost))
            TryPutCard();
        else if(myCost < selectCard.item.cost)
            c.transform.position = new Vector3(selectCardx, c.transform.position.y, c.transform.position.z);
    }

    void CardDrag(){
        if(!onMyCardArea){
            selectCard.MoveTransform(new PRS(Utils.MousePos, Utils.QI, selectCard.originPRS.scale), false);
        }
    }

    void DetectCardArea(){
        RaycastHit2D[] hits = Physics2D.RaycastAll(Utils.MousePos, Vector3.forward); 
        onMyCardArea = Array.Exists(hits, x=>x.collider.gameObject == cardArea);
    }

    void EnlargeCard(bool isEnlarged, Card card){
        if(isEnlarged){
            Vector3 enlargePos = new Vector3(myCardObjects.Find(x => x.GetComponent<Card>() == card).transform.position.x, card.originPRS.pos.y + 0.5f, -2f);
            card.MoveTransform(new PRS(enlargePos, Utils.QI, Vector3.one * 3.5f), false);
        }
        else
            card.MoveTransform(card.originPRS, false);
        card.GetComponent<Order>().SetMostFrontOrder(isEnlarged);
    }

    #endregion
}
