using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMachine_S : MonoBehaviour
{
    public static float dist;
    public static bool autoM_state = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(meScript.playerPosition, transform.position);
        if(dist < 10)
        {
            autoM_state = true;
        }
        else
        {
            autoM_state = false;
        }
    }
}
