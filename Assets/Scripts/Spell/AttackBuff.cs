using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : MonoBehaviour
{
    public Entity thisentity;
    public bool isShoot;
    [SerializeField] GameObject buffStat;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -1f, this.gameObject.transform.position.z);
        thisentity.magicShot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitobject = collision.gameObject;
        if (hitobject.GetComponent<Entity>() != null && hitobject.GetComponent<Entity>().isAlly && !hitobject.GetComponent<Entity>().isTower && !hitobject.GetComponent<Entity>().isMagic)
        {
            hitobject.GetComponent<Entity>().attack += thisentity.attack;
            var buffedob = Instantiate(buffStat, new Vector3(hitobject.transform.position.x, hitobject.transform.position.y + 1f, hitobject.transform.position.z), Utils.QI, hitobject.transform);
            buffedob.GetComponent<Buffed>().attack = thisentity.attack;
            Destroy(buffedob, 5f);
        }
    }
}
