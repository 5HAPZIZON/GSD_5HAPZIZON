using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyController : MonoBehaviour
{

    public float movePower = 5f;
    Rigidbody2D rigid;
    Animator animator;

    GameObject associate;

    void Start()
    {

        animator = GetComponent<Animator>();


    }

    void Update()
    {
        associate = GameObject.FindGameObjectWithTag("Associate");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float dis1 = Vector3.Distance(associate.transform.position, transform.position);

        if (dis1 >= 3.0f)
        {
            animator.SetBool("Attack", true);
            Vector3 moveVelocity = Vector3.zero;
            moveVelocity = Vector3.left;
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        else
        {
            Vector3 moveVelocity = Vector3.zero;
            transform.position += moveVelocity*Time.deltaTime;
            //Vector3 dir = associate.transform.position - transform.position;
            animator.SetBool("Attack", false);
        }

    }


    
}
