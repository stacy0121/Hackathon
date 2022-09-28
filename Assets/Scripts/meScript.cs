using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meScript : MonoBehaviour
{
    public static bool dial;
    public GameObject finish_UI;

    //ī�޶�
    public Camera cam;
    public GameObject camGameObject;

    //public GameObject clickEffect;

    public Camera frontCam;
    public GameObject frontCamGameobject;

    // ���� ȸ��
    float rotationX = 0.0f;

    Rigidbody rigid;
    private bool IsJumping;
    public static Vector3 playerPosition;

    // ������
    private RaycastHit hit;

    // �κ��丮 ����
    public static bool bag = false;
    bool phone = true;
    bool book = false;
    public GameObject bag_UI;
    public GameObject phone_UI;
    public GameObject book_UI;
    public GameObject phone_Real;
    public GameObject book_Real;
    public GameObject book_Real2;
    public GameObject bag_Real;

    // �� ������
    int phone_scale = -30;

    // ���� ���� ����
    public static int loan_ing_state = 0;  // 0: ����X, 1: å, 2: ����� �л���(��)

    // ���� �տ� ������ �ִ°�
    bool hand = false;

    // 244ȣ ������
    float rotation244 = 0;
    public GameObject door_244;
    bool rotation_244_state = false;

    public static bool quest = false;


    // quest
    public static float time;
    public GameObject QuestBell_UI;


    public GameObject tag_door_UI;

    public static bool takeBook = false;

    void Start()
    {
        IsJumping = false;
        rigid = GetComponent<Rigidbody>();

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ��ġ
        playerPosition = this.transform.position;

        // ���� ������
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement / 10);   // 20�̾���

        // ����
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!IsJumping)
            {
                IsJumping = true;
                GetComponent<Rigidbody>().AddForce(Vector3.up * 14.0f, ForceMode.Impulse);

            }
        }

        // ���� ȸ��
        float headX = Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(0))
        {
            rotationX = rotationX + headX * 5f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotationX - 90, 0);
        }


        // ������
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // ���콺�� Ŭ�� �� ������ ray�� ����
        
            if (Physics.Raycast(ray, out hit))  // ray�� �ε��� ��ü�� hit�� ���� ����
            {
                //���ܾ�
                if (hit.collider.gameObject.CompareTag("susan"))
                {
                    Debug.Log("test");
                    frontCamGameobject.SetActive(true); //ķ �ѱ�
                    camGameObject.SetActive(false);
                    dial = true;
                }

                // �Ա�
                if (hit.collider.gameObject.CompareTag("autoMachine"))      // �л��� ���
                {
                    if(autoMachine_S.autoM_state == true)
                    {
                        if(phone == false)
                        {
                            phone_scale = 30;
                            Debug.Log("test");
                            quest = true;
                            Destroy(tag_door_UI);
                        }
                    }
                }

                // �����
                if(loan_ing_state == 0)
                {
                    if (hit.collider.gameObject.CompareTag("loanMachine"))
                    {
                        if (loanMachine_S.loanM_state == true)
                        {
                            if (book == false)
                            {
                                Debug.Log("loan");
                                loan_ing_state = 1;
                            }
                        }
                    }
                }
                if(loan_ing_state == 1)
                {
                    if (hit.collider.gameObject.CompareTag("loanMachine"))
                    {
                        if (loanMachine_S.loanM_state == true)
                        {
                            if (phone == false)
                            {
                                Debug.Log("���� ��");
                                loan_ing_state = 2;
                                //quest = true;
                            }
                        }
                    }
                }
                

                // å
                if (hit.collider.gameObject.CompareTag("book"))      // �л��� ���
                {
                    book = true;
                    book_Real.SetActive(false);
                    takeBook = true;
                    //quest = true;
                    //time = 0;
                }

                // 244ȣ �� ����
                if (hit.collider.gameObject.CompareTag("244door"))
                {
                    rotation_244_state = true;
                }

                // ���� ì���
                if (hit.collider.gameObject.CompareTag("bag"))
                {
                    if (bag_S.bag_state == true)
                    {
                        if (bag == false)
                        {
                            Debug.Log("bag");
                            bag = true;
                            bag_Real.SetActive(false);
                        }
                    }
                }
            }
        }

        // 244 �� ȸ��
        if(rotation_244_state == true)
        {
            rotation244++;
            if (rotation244 < 100)
            {
                door_244.transform.Rotate(new Vector3(0, 1, 0) * rotation244 / 50);
            }
        }
        

        phone_scale--;
        if(phone_scale > 0)
        {
            phone_Real.transform.localScale -= new Vector3(1.0f, 1.0f, 1.0f);
        }else if(phone_scale > -30)
        {
            phone_Real.transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
        }


        // �κ��丮
        // ��
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(phone == true)
            {
                if(hand == false)
                {
                    phone = false;
                    phone_Real.SetActive(true);
                    hand = true;
                }
            }
            else
            {
                phone = true;
                hand = false;
                phone_Real.SetActive(false);
            }
            
        }
        // å
        if (Input.GetKeyDown(KeyCode.Alpha2) && takeBook == true)
        {
            if (book == true)
            {
                if (hand == false)
                {
                    book = false;
                    book_Real2.SetActive(true);
                    hand = true;
                }
            }
            else
            {
                book = true;
                hand = false;
                book_Real2.SetActive(false);
            }
        }

        if (bag == true)
        {
            bag_UI.SetActive(true);
        }
        else
        {
            bag_UI.SetActive(false);
        }

        if (phone == true)
        {
            phone_UI.SetActive(true);
        }
        else
        {
            phone_UI.SetActive(false);
        }

        if (book == true)
        {
            book_UI.SetActive(true);
        }
        else
        {
            book_UI.SetActive(false);
        }


        // ����Ʈ
        if (quest == true)
        {
            QuestBell_UI.gameObject.SetActive(false);
            time += Time.deltaTime;
            if (time > 2)
            {
                QuestBell_UI.gameObject.SetActive(true);
                //time = 0;
                //quest = false;
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        IsJumping = false;
        if(collision.gameObject.tag == "finish")
        {
            finish_UI.SetActive(true);
        }

    }
    
}
