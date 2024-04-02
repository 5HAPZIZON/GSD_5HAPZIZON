using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForGumi : MonoBehaviour
{
    [SerializeField] Entity thisEntity;
    public List<GameObject> FoundObjects;
    public GameObject enemy;
    public float shortDis;

    SpriteRenderer rend;

    public float movePower = 5f;
    Rigidbody2D rigid;
    Animator animator;

    bool isAttack = false;
    public GameObject fire;
    public Transform firepos;
    public float attackTimer;
    float attackTime = 0;
    Vector3 moveVelocity = Vector3.zero;


    void Start()
    {

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (thisEntity.health > 0)
        {
            Move();
            if (isAttack == true && attackTime >= attackTimer)
            {
                Instantiate(fire, firepos.position, transform.rotation);
                attackTime = 0;
            }
            attackTime += Time.deltaTime;
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
            moveVelocity = Vector3.zero;

            

            if (dis >= 5.0f)
            {
                isAttack = false;
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("Attack", false);
                //Vector3 moveVelocity = Vector3.zero;
                moveVelocity = Vector3.right;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else if (dis <= -5.0f)
            {
                isAttack = false;
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("Attack", false);
                //Vector3 moveVelocity = Vector3.zero;
                moveVelocity = Vector3.left;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else
            {
                isAttack = true;
                //Vector3 dir = associate.transform.position - transform.position;
                animator.SetBool("Attack", true);
               
            }
        }
        else
        {
            isAttack = false;
            animator.SetBool("Attack", false);
            transform.position = Vector3.zero;

        }

    }

    GameObject FindClosestEnemy()
    {
        GameObject[] target;
        target = GameObject.FindGameObjectsWithTag("Enemy");
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

    public void SetHp(int damage)
    {
        thisEntity.health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if(hitobject.GetComponent<Entity>() != null && !hitobject.GetComponent<Entity>().isAlly)
        {
            //hitobject.GetComponent<Entity>().health -= thisEntity.attack;
            //rend.material.color = Color.red;
            if (thisEntity.health <= 0)
                animator.SetBool("Die", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // rend.material.color = Color.white;
    }
}
