using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMain_Image : MonoBehaviour
{

    public GameObject DogMain;
    public GameObject CatMain;
    public GameObject DogPuppet;
    public GameObject CatPuppet;


    void Awake()
    {
        
        if(ForData.forData.forMainCharacter == 1)
        {
            Instantiate(DogMain, new Vector3(-1.9f,-2.0f,0),Quaternion.identity);
            Instantiate(DogPuppet, new Vector3(-1.9f, -2.0f, 0), Quaternion.identity);
        }
        else if(ForData.forData.forMainCharacter == 2)
        {
            Instantiate(CatMain, new Vector3(-1.9f, -2.0f, 0), Quaternion.identity);
            Instantiate(CatPuppet, new Vector3(-1.9f, -2.0f, 0), Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
