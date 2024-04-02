using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTutorial : MonoBehaviour
{

    public Canvas tutorial;
    
    void Start()
    {
        if(TimeUI.Wave == 1)
        {
            tutorial.gameObject.SetActive(true);
        }
    }

    
    void Update()
    {
        
    }
}
