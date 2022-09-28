using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loanMachine_S : MonoBehaviour
{
    float dist;
    public static bool loanM_state = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(meScript.playerPosition, this.transform.position);
        if(dist < 20)
        {
            loanM_state = true;
        }
        else
        {
            loanM_state = false;
        }
    }
}
