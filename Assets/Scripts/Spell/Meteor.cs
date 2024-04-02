using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Entity thisentity;
    public bool isShoot;
    Animator animator;
    float down;

    void ShootMeteor(bool isShoot){
        if(isShoot){
            down = 0.5f;
        }
        else{
            down = 0f;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -3.2f, this.gameObject.transform.position.z);
            animator.SetBool("Boom", true);
            thisentity.magicShot = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if (hitobject.GetComponent<Entity>() != null && !hitobject.GetComponent<Entity>().isAlly)
        {
            hitobject.GetComponent<Entity>().health -= thisentity.attack;
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.red;
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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 12f, this.gameObject.transform.position.z);
        isShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        ShootMeteor(isShoot);
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - down, this.gameObject.transform.position.z);
    }
}
