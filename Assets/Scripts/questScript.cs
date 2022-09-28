using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questScript : MonoBehaviour
{
    public static float time;

    public GameObject QuestBell_UI;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (meScript.quest == true) { 
            time += Time.deltaTime;
            if (time > 2)
            {
                QuestBell_UI.gameObject.SetActive(true);
            }
        }
    }
}
