using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBow : MonoBehaviour
{
    [SerializeField] Entity BowEntity;
    public float movePower;
    int attack;

    void Start()
    {
        attack = BowEntity.attack;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * (-1) * movePower * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * movePower * Time.deltaTime);
        }

        if (transform.position.x < -20f || transform.position.x > 30f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if (hitobject.GetComponent<Entity>() != null && hitobject.GetComponent<Entity>().isAlly)
        {
            hitobject.GetComponent<Entity>().health -= attack;
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.red;

        }
        else if (hitobject.gameObject.tag == "Castle")
        {
            hitobject.GetComponent<ForCastle>().nowHp -= attack;
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if (hitobject.GetComponent<Entity>() != null && hitobject.GetComponent<Entity>().isAlly
            || hitobject.gameObject.tag == "Castle")
        {
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }
}
