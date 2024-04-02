using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameCamera : MonoBehaviour
{

    Vector3 targetPos;

    public float offsetX = 0.0f;
    public float offsetY = -2.5f;
    public float offsetZ = -10.0f;
    public float cameraSpeed = 10.0f;

   
    void Start()
    {
        

    }



    void Update()
    {
       
    }

    private void FixedUpdate()
    {

        if ((transform.position.x + Input.GetAxis("Horizontal") >= -3.9f) && transform.position.x + Input.GetAxis("Horizontal") <= 14.5f)
        {
            targetPos = new Vector3(transform.position.x + Input.GetAxis("Horizontal"),
                                offsetY,
                                transform.position.z);
        }
        else if (transform.position.x + Input.GetAxis("Horizontal") <= -3.9f)
        {
            targetPos = new Vector3(-3.9f, offsetY,
                                transform.position.z);
        }
        else if (transform.position.x + Input.GetAxis("Horizontal") >= 14.5f)
        {
            targetPos = new Vector3(14.5f, offsetY,
                                transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position,
                                            targetPos, Time.deltaTime * cameraSpeed);
    }

    


}


