using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{

    private ButtonInteraction inductionButton;
    public PotInteraction pot;
    public Water water;

    public GameObject fire;
    public GameObject end;
    public GameObject retry;
    public GameObject good;

    public float LimitTime;
    public float minTime;
    public float maxTime;
    public float ftime;

    public bool ingredients = false; //식재료
    private bool finsh = false;
    private bool table = false;

    void Start()
    {
        inductionButton = GameObject.Find("inductionButton").GetComponent<ButtonInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inductionButton.isButtonPressed && pot.isPotOnInduction)
        {
            if (water.water != true)
            {
                //다시 UI 버튼으로 GameStateLoad1 스크립트 할당하기
                retry.SetActive(true);
            }
            else if (water.water == true)
            {
                if (ingredients == true) //물을 넣고 재료를 넣었는가?
                {
                    LimitTime -= Time.deltaTime;
                    Debug.Log(LimitTime); // 시간 UI
                    if (LimitTime >= minTime && LimitTime <= maxTime && (pot.isPotOnInduction == false || inductionButton.isButtonPressed == false) && finsh == false) 
                    {
                        finsh = true;
                        good.SetActive(true);
                        //완성 알아서 보글보글 한 후 완성
                    }
                    else if ((LimitTime > maxTime || LimitTime < minTime) && (pot.isPotOnInduction == false || inductionButton.isButtonPressed == false))
                    {
                        //no 탔는지 덜익었는지 ui로 띄운 후 재시작 UI 버튼으로 GameStateLoad2 스크립트 할당하기
                        LimitTime = 10f;
                        fire.SetActive(true);
                        retry.SetActive(true);
                    }
                }
            }
        }     

        if (table == true)
        {
            Debug.Log("성공"); // 성공 UI 띄우는 곳
            end.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen") && collision.gameObject.CompareTag("egg"))
        {
            ingredients = true;
        }

        if (collision.gameObject.CompareTag("Table")) 
        {
            table = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen") && collision.gameObject.CompareTag("egg"))
        {
            ingredients = false;
        }
    }
}
