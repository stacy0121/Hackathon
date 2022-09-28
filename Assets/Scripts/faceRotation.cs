using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceRotation : MonoBehaviour
{
    // 얼굴 회전
    float rotationY = 0.0f;


    void Start()
    {
        
    }


    void Update()
    {
        // 얼굴 위 아래 회전
        if (Input.GetMouseButton(0))
        {
            float headY = Input.GetAxis("Mouse Y");
            rotationY = rotationY + headY * 1f;
            transform.eulerAngles = new Vector3(-rotationY, transform.eulerAngles.y, 0);
        }

    }
}
