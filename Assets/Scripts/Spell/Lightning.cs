using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public Entity thisentity;
    public bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0f, this.gameObject.transform.position.z);
        thisentity.magicShot = true;
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
}
