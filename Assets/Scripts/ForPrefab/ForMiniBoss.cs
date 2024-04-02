using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForMiniBoss : MonoBehaviour
{
    [SerializeField] Entity thisEntity;
    public List<GameObject> FoundObjects;
    public GameObject associate;
    public float shortDis;

    public GameObject forAttackSize;

    GameObject castle;


    public float movePower = 5f;
    Animator animator;


    Vector3 moveVelocity = Vector3.zero;

    void Start()
    {

        animator = GetComponent<Animator>();

    }

    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (thisEntity.health > 0)
        {
            Move();
        }
        else
        {
            moveVelocity = Vector3.zero;
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }

    }

    void Move()
    {
        if (FindClosestEnemy() != null)
        {
            //float dis = Vector3.Distance(FindClosestEnemy().transform.position, transform.position);
            float dis = FindClosestEnemy().transform.position.x - transform.position.x;
            if (dis >= 1.0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", true);
                moveVelocity = Vector3.zero;
                moveVelocity = Vector3.right;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else if (dis <= -1.0f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", true);
                moveVelocity = Vector3.zero;
                moveVelocity = Vector3.left;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else
            {
                //Vector3 dir = associate.transform.position - transform.position;
                animator.SetBool("Attack", true);
                animator.SetBool("Walk", false);

            }
        }
        else
        {
            castle = GameObject.FindGameObjectWithTag("Castle");
            float dist = castle.transform.position.x - transform.position.x;

            if (dist >= 1.0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", true);
                moveVelocity = Vector3.zero;
                moveVelocity = Vector3.right;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else if (dist <= -1.0f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", true);
                moveVelocity = Vector3.zero;
                moveVelocity = Vector3.left;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else
            {
                //Vector3 dir = associate.transform.position - transform.position;
                animator.SetBool("Attack", true);
                animator.SetBool("Walk", false);

            }
        }

    }

    GameObject FindClosestEnemy()
    {
        GameObject[] target;
        target = GameObject.FindGameObjectsWithTag("Associate");
        GameObject closest = null;
        float distance = Mathf.Infinity;

        Vector3 position = transform.position;
        foreach (GameObject go in target)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        return closest;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if (hitobject.GetComponent<Entity>() != null && hitobject.GetComponent<Entity>().isAlly)
        {
            hitobject.GetComponent<Entity>().health -= thisEntity.attack;
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.red;

        }
        else if (hitobject.gameObject.tag == "Castle")
        {
            hitobject.GetComponent<ForCastle>().nowHp -= thisEntity.attack;
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.red;
        }

        if (thisEntity.health <= 0)
            animator.SetBool("Die", true);
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
