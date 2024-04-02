using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppet_CatController : MonoBehaviour
{

    public float speed;
    public float distance;
    Transform mainCharacter;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        mainCharacter = GameObject.FindWithTag("MainCharacter").transform;

    }

    void Update()
    {

        if(Mathf.Abs(transform.position.x - mainCharacter.position.x) > distance)
        {
             
            
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
            anim.SetBool("IsWalking", true);
            DirectionPet();

        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    void DirectionPet()
    {
        if(transform.position.x - mainCharacter.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            //transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
