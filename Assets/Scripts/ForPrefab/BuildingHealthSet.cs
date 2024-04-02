using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealthSet : MonoBehaviour
{
    [SerializeField] Entity thisEntity;
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if (!hitobject.GetComponent<Entity>().isAlly)
        {
            hitobject.GetComponent<Entity>().health -= thisEntity.attack;
            if (thisEntity.health <= 0)
            {

            }
        }
    }
}
