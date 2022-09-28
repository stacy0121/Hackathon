using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_R2 : MonoBehaviour
{
    public static float dist;
    public static float moving;
    Vector3 first_position;

    // Start is called before the first frame update
    void Start()
    {
        first_position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(meScript.playerPosition, this.transform.position);  // 문과 나의 거리
        if (dist > 390)
        {
            if (Vector3.Distance(first_position, this.transform.position) < 2f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.04f);
            }
            else
            {
                transform.position = transform.position;
            }
        }
        else
        {
            if (Vector3.Distance(first_position, this.transform.position) != 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.04f);
            }
        }



    }
}