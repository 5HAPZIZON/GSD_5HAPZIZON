using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFire : MonoBehaviour
{
    [SerializeField] Entity GumiEntity;
    public float movePower;
    GameObject target;
    int attack;


    void Start()
    {
        attack = GumiEntity.attack;
    }

    void Update()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * movePower * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * (-1) * movePower * Time.deltaTime);
        }


        if (transform.position.x < -20f || transform.position.x > 30f) Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if(hitobject.GetComponent<Entity>() != null && !hitobject.GetComponent<Entity>().isAlly){
            hitobject.GetComponent<Entity>().health -= attack;
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.red;
            //Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if (hitobject.GetComponent<Entity>() != null && !hitobject.GetComponent<Entity>().isAlly)
        {
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }

}
