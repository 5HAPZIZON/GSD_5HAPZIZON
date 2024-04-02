using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMainCameraForChar : MonoBehaviour
{
    public GameObject target;

    public GameObject Main;

    Vector3 targetPos;

    public float offsetX = 0.0f;
    public float offsetY = 3.5f;
    public float offsetZ = -10.0f;
    public float cameraSpeed = 10.0f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCharacter");
    }

    void Update()
    {


    }

    private void FixedUpdate()
    {
        if ((target.transform.position.x + offsetX >= -13.8f) && target.transform.position.x + offsetX <= 3.7f)
        {
            targetPos = new Vector3(target.transform.position.x + offsetX,
                                offsetY,
                                target.transform.position.z + offsetZ);
        }
        else if(target.transform.position.x + offsetX <= -13.8)
        {
            targetPos = new Vector3(-13.8f, offsetY,
                                target.transform.position.z + offsetZ);
        }
        else if(target.transform.position.x + offsetX >= 3.7f)
        {
            targetPos = new Vector3(3.7f, offsetY,
                                target.transform.position.z + offsetZ);
        }

        transform.position = Vector3.Lerp(transform.position,
                                            targetPos, Time.deltaTime * cameraSpeed);
    }
}
