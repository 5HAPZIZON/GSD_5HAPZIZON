using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter_Cat_Controller : MonoBehaviour
{

    public float movePower = 10f;
    Rigidbody2D rigid;
    Animator animator;


    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal")==0)
        {
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("isWalking", false);
           
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("isWalking", false);
        }

        

       // if (Input.GetButtonDown("Jump") && scanObject != null)
       //     gM.Action(scanObject);
    }

    private void FixedUpdate()
    {
        Move();
        //Debug.DrawRay(rigid.position, direction * 2f, new Color(0,1,0));
        

       
    }

    void Move()

    {
        Vector3 moveVelocity = Vector3.zero;

        //if (transform.position.x >= -26.7f && transform.position.x <= 16.8f)
        
            

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(1, 1, 1);
            }
        

            transform.position += moveVelocity * movePower * Time.deltaTime;
        
        
    }
}
