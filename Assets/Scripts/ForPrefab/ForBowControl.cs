using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBowControl : MonoBehaviour
{
    [SerializeField] Entity thisEntity;
    public List<GameObject> FoundObjects;
    public GameObject associate;
    public float shortDis;

    GameObject castle;

    SpriteRenderer rend;

    public float movePower = 5f;
    Rigidbody2D rigid;
    Animator animator;

    bool isAttack = false;
    public GameObject bow;
    public Transform bowpos;
    public float attackTimer;
    float attackTime = 0f;

    Vector3 moveVelocity = Vector3.zero;


    void Start()
    {

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

    }

    private void Awake()
    {
       
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
                Instantiate(bow, bowpos.position,transform.rotation);
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
        attackTime += Time.deltaTime;
        if (FindClosestEnemy() != null)
        {

            moveVelocity = Vector3.zero;

            float dis = FindClosestEnemy().transform.position.x - transform.position.x;
            
            if (dis >= 5.0f)
            {
                isAttack = false;
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("Attack", true);
                moveVelocity = Vector3.right;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else if (dis <= -5.0f)
            {
                isAttack = false;
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("Attack", true);
                moveVelocity = Vector3.left;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else
            {
                isAttack = true;
                animator.SetBool("Attack", false);               

            }

        }
        else
        {
            castle = GameObject.FindGameObjectWithTag("Castle");
            float dist = castle.transform.position.x - transform.position.x;

            if (dist >= 5.0f)
            {
                isAttack = false;
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("Attack", true);
                moveVelocity = Vector3.right;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else if (dist <= -5.0f)
            {
                isAttack = false;
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("Attack", true);
                moveVelocity = Vector3.left;
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else
            {
                isAttack = true;
                animator.SetBool("Attack", false);

            }
            /*isAttack = false;
            animator.SetBool("Attack", true);
            transform.position = Vector3.zero;*/
        }


    }

    GameObject FindClosestEnemy()
    {
        GameObject[] target;
        target = GameObject.FindGameObjectsWithTag("Associate");
        GameObject closest = null;
        float distance = Mathf.Infinity;

        Vector3 position = transform.position;
        foreach(GameObject go in target)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
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
            
            if (thisEntity.health <= 0)
                animator.SetBool("Die", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

}
