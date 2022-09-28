using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    [SerializeField] GameObject[] dial_P = null;

    bool state = false;

    int num = 0;

    bool once = true;

    //카메라
    public Camera cam;
    public GameObject camGameObject;

    //public GameObject clickEffect;

    public Camera frontCam;
    public GameObject frontCamGameobject;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (meScript.dial == true)
        {
            if (once == true)
            {
                for (int i = 0; i < dial_P.Length; i++)
                {
                    dial_P[i].SetActive(true);
                }

                once = false;
            }





            if (Input.GetKeyDown(KeyCode.Space))
            {
                dial_P[num].SetActive(false);
                num++;
                Debug.Log(num);
                if (num == dial_P.Length)
                {
                    state = true;
                }
            }



            if (state == true)
            {
                camGameObject.SetActive(true);
                frontCamGameobject.SetActive(false); //캠 켜기
            }

        }
    }

}