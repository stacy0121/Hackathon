using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quests : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txt;

    void Start()
    {
        txt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(meScript.time > 2 && meScript.takeBook != true)
        {
            txt.text = "도서를 대출해보자.\n1층 일반 도서실에 눈에 띄는 책이 있는데...?";
        }
        else if(meScript.takeBook== true && meScript.loan_ing_state != 2)
        {
            txt.text = "무인 대출기에 책을 놓고 모바일 학생증으로 책을 대출하자";
        }
        else if (meScript.loan_ing_state == 2 && meScript.bag != true)
        {
            txt.text = "대출 끝!\n가방을 가지러 2층 오스카라운지 스터디룸으로 가보자";
        }
        else if (meScript.bag == true)
        {
            txt.text = "가방을 찾았다!\n이제 집으로 가볼까? 그런데...?";
        }
    }
}
