using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Entity thisentity;
    [SerializeField] Sprite plusone_left;
    [SerializeField] Sprite plustwo_left;
    [SerializeField] Sprite plusthree_left;
    [SerializeField] Sprite plusone_right;
    [SerializeField] Sprite plustwo_right;
    [SerializeField] Sprite plusthree_right;
    [SerializeField] SpriteRenderer thisrenderer;

    // Start is called before the first frame update
    void Start()
    {
        if(thisentity.item.reinforce == 1){
            thisrenderer.sprite = plusone_right;
        }
        else if(thisentity.item.reinforce == 2){
            thisrenderer.sprite = plustwo_right;
        }
        else if(thisentity.item.reinforce == 3){
            thisrenderer.sprite = plusthree_right;
        }

        this.transform.position = new Vector3(this.transform.position.x, -3.5f, this.transform.position.z);
    }
}
