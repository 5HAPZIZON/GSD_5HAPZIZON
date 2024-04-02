using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetResolution();
    }

    public void SetResolution(){
        int setWidth = 1280;
        int setHeight = 768;
        Screen.SetResolution(setWidth, setHeight, false);
    }
}
