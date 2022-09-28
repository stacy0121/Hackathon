using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag_S : MonoBehaviour
{
    float dist;
    public static bool bag_state = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(meScript.playerPosition, transform.position);
        if(dist < 15)
        {
            bag_state = true;
        }
        else
        {
            bag_state = false;
        }
    }
}
