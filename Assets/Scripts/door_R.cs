using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_R : MonoBehaviour
{
    public static float dist;
    public static float moving = 121;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dist = Mathf.Abs(Vector3.Distance(meScript.playerPosition, transform.position));
        if (dist < 16 && moving > 0)
        {
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
            moving--;
        }
        else if (dist > 16 && moving <= 120)
        {
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
            moving++;
        }
    }

}
