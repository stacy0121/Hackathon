using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceRotation : MonoBehaviour
{
    // �� ȸ��
    float rotationY = 0.0f;


    void Start()
    {
        
    }


    void Update()
    {
        // �� �� �Ʒ� ȸ��
        if (Input.GetMouseButton(0))
        {
            float headY = Input.GetAxis("Mouse Y");
            rotationY = rotationY + headY * 1f;
            transform.eulerAngles = new Vector3(-rotationY, transform.eulerAngles.y, 0);
        }

    }
}
