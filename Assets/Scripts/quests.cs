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
            txt.text = "������ �����غ���.\n1�� �Ϲ� �����ǿ� ���� ��� å�� �ִµ�...?";
        }
        else if(meScript.takeBook== true && meScript.loan_ing_state != 2)
        {
            txt.text = "���� ����⿡ å�� ���� ����� �л������� å�� ��������";
        }
        else if (meScript.loan_ing_state == 2 && meScript.bag != true)
        {
            txt.text = "���� ��!\n������ ������ 2�� ����ī����� ���͵������ ������";
        }
        else if (meScript.bag == true)
        {
            txt.text = "������ ã�Ҵ�!\n���� ������ ������? �׷���...?";
        }
    }
}
