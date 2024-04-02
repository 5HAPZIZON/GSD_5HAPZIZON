using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffed : MonoBehaviour
{
    public int attack;
    void OnDestroy(){
        this.transform.parent.GetComponent<Entity>().attack -= attack;
    }
}
