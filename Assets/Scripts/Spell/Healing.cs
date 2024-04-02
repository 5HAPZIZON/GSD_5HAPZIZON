using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public Entity thisentity;
    public bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -1f, this.gameObject.transform.position.z);
        thisentity.magicShot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if (hitobject.GetComponent<Entity>() != null && hitobject.GetComponent<Entity>().isAlly && !hitobject.GetComponent<Entity>().isMagic)
        {
            hitobject.GetComponent<Entity>().health += thisentity.attack;
            hitobject.GetComponent<SpriteRenderer>().material.color = Color.green;
            StartCoroutine(WaitAndBack(hitobject, 0.5f));
        }
    }

    private IEnumerator WaitAndBack(GameObject hitobject, float waittime){
        yield return new WaitForSecondsRealtime(waittime);
        hitobject.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
