using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{
    private ButtonInteraction inductionButton;
    private PotInteraction pot;
    public GameObject fire;
    public GameObject potObject;
    public float LimitTime;
    public float ftime;

    private bool water = true;
    private bool ingredients = true; //식재료
    private bool finsh = true;

    void Start()
    {
        inductionButton = GameObject.Find("inductionButton").GetComponent<ButtonInteraction>();
        pot = potObject.GetComponent<PotInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inductionButton.isButtonPressed && pot.isPotOnInduction)
        {
            if (water != true)
            {
                if (inductionButton.isButtonPressed == true)
                {
                    //다시
                }
            }
            else if (water == true)
            {
                if (ingredients == true) //제 시간 안에 클릭을 했는가?
                {
                    LimitTime -= Time.deltaTime;
                    Debug.Log(LimitTime);
                    if (LimitTime >= 4 && LimitTime <= 6 && Input.GetKeyDown(KeyCode.K) && finsh == false) //yes 재료를 넣는다
                    {
                        finsh = true;
                        //완성 알아서 보글보글 한 후 완성
                        Debug.Log("완성");
                    }
                    else if (LimitTime < 0)
                    {
                        //no 탔는지 덜익었는지 ui로 띄운 후 재시작
                        LimitTime = 10f;
                        Debug.Log("다시");
                        water = false;
                        ingredients = false;
                        finsh = false;
                        pot.isPotOnInduction = false;
                        inductionButton.isButtonPressed = false;
                    }
                }
            }
        }
        //5초 경과(ui로 인덕션 끄라는 메시지 띄우기)
        if (finsh == true) 
        {
            ftime -= Time.deltaTime;
            Debug.Log(ftime);
            if (ftime > 0 && inductionButton.isButtonPressed == false) // 제한시간 내에 했고 버튼이 꺼져있는 상태가 되면
            {
                //라면 옮기기로 이동
                Debug.Log("성공");
                finsh = false;
            }
            else if (ftime < 0 && inductionButton.isButtonPressed == true) // 제한시간 넘기고 버튼이 켜져있는 상태가 되면
            {
                //불남
                fire.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen"))
        {
            ingredients = true;
        }
        if (collision.gameObject.CompareTag("water"))
        {
            water = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen"))
        {
            ingredients = false;
        }
        if (collision.gameObject.CompareTag("water"))
        {
            water = false;
        }
    }
}
