using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meScript : MonoBehaviour
{
    public static bool dial;
    public GameObject finish_UI;

    //카메라
    public Camera cam;
    public GameObject camGameObject;

    //public GameObject clickEffect;

    public Camera frontCam;
    public GameObject frontCamGameobject;

    // 몸의 회전
    float rotationX = 0.0f;

    Rigidbody rigid;
    private bool IsJumping;
    public static Vector3 playerPosition;

    // 레이저
    private RaycastHit hit;

    // 인벤토리 상태
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

    // 폰 스케일
    int phone_scale = -30;

    // 대출 진행 상태
    public static int loan_ing_state = 0;  // 0: 진행X, 1: 책, 2: 모바일 학생증(끝)

    // 나의 손에 도구가 있는가
    bool hand = false;

    // 244호 문열기
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
        // 나의 위치
        playerPosition = this.transform.position;

        // 나의 움직임
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement / 10);   // 20이었음

        // 점프
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!IsJumping)
            {
                IsJumping = true;
                GetComponent<Rigidbody>().AddForce(Vector3.up * 14.0f, ForceMode.Impulse);

            }
        }

        // 몸의 회전
        float headX = Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(0))
        {
            rotationX = rotationX + headX * 5f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotationX - 90, 0);
        }


        // 레이저
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // 마우스가 클릭 된 곳으로 ray를 던짐
        
            if (Physics.Raycast(ray, out hit))  // ray에 부딪힌 물체를 hit에 집어 넣음
            {
                //수잔씨
                if (hit.collider.gameObject.CompareTag("susan"))
                {
                    Debug.Log("test");
                    frontCamGameobject.SetActive(true); //캠 켜기
                    camGameObject.SetActive(false);
                    dial = true;
                }

                // 입구
                if (hit.collider.gameObject.CompareTag("autoMachine"))      // 학생증 찍기
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

                // 대출기
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
                                Debug.Log("대출 끝");
                                loan_ing_state = 2;
                                //quest = true;
                            }
                        }
                    }
                }
                

                // 책
                if (hit.collider.gameObject.CompareTag("book"))      // 학생증 찍기
                {
                    book = true;
                    book_Real.SetActive(false);
                    takeBook = true;
                    //quest = true;
                    //time = 0;
                }

                // 244호 문 열기
                if (hit.collider.gameObject.CompareTag("244door"))
                {
                    rotation_244_state = true;
                }

                // 가방 챙기기
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

        // 244 문 회전
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


        // 인벤토리
        // 폰
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
        // 책
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


        // 퀘스트
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
