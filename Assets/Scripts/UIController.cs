using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] ItemSO itemso;
    Item[] items;

    private void Start()
    {
        CloseShop.onClick.AddListener(DeActiveShop);
        NineTailedFox.onClick.AddListener(NineTailedFoxOnclick);
        Dark.onClick.AddListener(DarkOnclick);
        StarFish.onClick.AddListener(StarFishOnclick);
        Tower.onClick.AddListener(TowerOnclick);
        attackPower.onClick.AddListener(attackPowerOnclick);
        attackSpeed.onClick.AddListener(attackSpeedOnclick);
        whiteTiger.onClick.AddListener(whiteTigerOnclick);
        Lightning.onClick.AddListener(LightningOnclick);
        Fire.onClick.AddListener(FireOnclick);
        movingSpeed.onClick.AddListener(movingSpeedOnclick);
        Heal.onClick.AddListener(HealOnclick);
        items = itemso.items;
    }

    private void Update()
    {
        MoneyText.text = Money.ToString();
        if (Input.GetMouseButtonUp(0))
        {
            RayShop();
        }
    }

    public GameObject shop;
    public Button CloseShop;
    public Button NineTailedFox; public Button Dark;
    public Button StarFish; public Button Tower;
    public Button attackPower; public Button attackSpeed;
    public Button whiteTiger; public Button Lightning;
    public Button Fire; public Button movingSpeed;
    public Button Heal;
    public bool isStoreActive;
    public static int Money = 0;
    public Text MoneyText;


    public void DarkOnclick()
    {
        if (items[0].reinforce < 3 && Money >= 5)
        {
            items[0].attack += 15;
            items[0].health += 100;
            items[0].reinforce++;
            Money -= 5;
        }
    }

    public void NineTailedFoxOnclick()
    {
        if(items[1].reinforce < 3 && Money >= 5)
        {
            items[1].attack += 20;
            items[1].health += 50;
            items[1].reinforce++;
            Money -= 5;
        }
    } 

    public void StarFishOnclick()
    {
        if (items[2].reinforce < 3 && Money >= 5)
        {
            items[2].attack += 10;
            items[2].health += 150;
            items[2].reinforce++;
            Money -= 5;
        }            
    }

    public void LightningOnclick()
    {
        if (items[3].reinforce < 3 && Money >= 5)
        {
            items[3].attack += 50;
            items[3].reinforce++;
            Money -= 5;
        }
    }

    public void FireOnclick()
    {
        if (items[4].reinforce < 3 && Money >= 5)
        {
            items[4].attack += 30;
            items[4].reinforce++;
            Money -= 5;
        }
    }

    public void HealOnclick()
    {
        if (items[5].reinforce < 3 && Money >= 5)
        {
            items[5].attack += 50;
            items[5].reinforce++;
            Money -= 5;
        }
    }

    public void attackSpeedOnclick()
    {
        
    }

    public void TowerOnclick()
    {
        if (items[7].reinforce < 3 && Money >= 5)
        {
            items[7].health += 200;
            items[7].reinforce++;
            Money -= 5;
        }
    }

    public void attackPowerOnclick()
    {
        if (items[6].reinforce < 3 && Money >= 5)
        {
            items[6].attack += 15;
            items[6].reinforce++;
            Money -= 5;
        }
    }

    public void whiteTigerOnclick()
    {
        
    }

    public void movingSpeedOnclick()
    {
        
    }

    public void RayShop()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -10;
            RaycastHit2D hit2D = Physics2D.Raycast(mousePos, transform.forward, 30);
            if (hit2D.collider != null)
            {
                if (hit2D.collider.CompareTag("Store"))
                {
                    if (!isStoreActive)
                    {
                        ActiveShop(true);
                    }
                }
            }
    }
            

    public void ActiveShop(bool isOpen)
    {
        isStoreActive = isOpen;
        shop.SetActive(isOpen);
         
    }
    public void DeActiveShop()
    {
        ActiveShop(false);
    }
}
