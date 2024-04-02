using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//씬끼리 공유해야하는 데이터 저장 스크립트

public class ForData : MonoBehaviour
{
    public static ForData forData;

    public int forMainCharacter;
    public int cost = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //새로운 씬으로 넘어가도 오브젝트 유지

        if(forData == null)
        {
            forData = this;
        }
        else if(forData != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
