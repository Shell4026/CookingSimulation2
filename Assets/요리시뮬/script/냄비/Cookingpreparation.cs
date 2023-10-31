using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{
    public Pot pot;
    public PotInteraction potInteraction;
    public ButtonInteraction inductionButton;

    [Header("자막")]
    [SerializeField] private Message sub_start;
    [SerializeField] private Message sub_materials;
    [SerializeField] private Message sub_fire;
    [SerializeField] private Message sub_end;
    [SerializeField] private Message sub_retry;
    [SerializeField] private Message sub_good;
    [Header("음성")]
    [SerializeField] private AudioSource audio_start;
    [SerializeField] private AudioSource audio_materials;
    [SerializeField] private AudioSource audio_fire;
    [SerializeField] private AudioSource audio_end;
    [SerializeField] private AudioSource audio_retry;
    [SerializeField] private AudioSource audio_good;
    [Header("튜토리얼 자막")]
    [SerializeField] private Message sub_tutorial1; // 무빙
    [SerializeField] private Message sub_tutorial2; // 잡기
    [SerializeField] private Message sub_tutorial3; // 도마로 가라

    [Space(10.0f)]
    public float LimitTime;
    public float minTime;
    public float maxTime;
    public float ftime;

    public bool ingredients = false; //식재료
    private bool finsh = false;
    private bool table = false;

    void Start()
    {
        Invoke(nameof(GameStart), 1.0f); //1초뒤 첫 시작
    }

    public void GameStart()
    {
        sub_start.gameObject.SetActive(true);
        audio_start.Play();

        StartCoroutine(LevelStartDelay(1, 5.0f));
    }

    IEnumerator LevelStartDelay(int lv, float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelStart(lv);
    }

    public void OffSubtitles()
    {
        sub_tutorial1.gameObject.SetActive(false);
        sub_tutorial2.gameObject.SetActive(false);
        sub_tutorial3.gameObject.SetActive(false);
    }

    public void LevelStart(int lv)
    {
        switch(lv)
        {
            case 0:
                GameStart();
                break;
            case 1:
                sub_tutorial1.gameObject.SetActive(true);
                StartCoroutine(LevelStartDelay(2, 9.0f));
                break;
            case 2:
                sub_materials.gameObject.SetActive(true);
                audio_materials.Play();
                StartCoroutine(LevelStartDelay(3, 3.0f));
                break;
            case 3:
                sub_tutorial2.gameObject.SetActive(true);
                break;
            case 4:
                OffSubtitles();
                sub_tutorial3.gameObject.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inductionButton.isButtonPressed && potInteraction.isPotOnInduction)
        {
            if (pot != true)
            {
                //다시 UI 버튼으로 GameStateLoad1 스크립트 할당하기
                sub_retry.gameObject.SetActive(true);
            }
            else if (pot.GetWaterAmount() > 0.9f)
            {
                if (ingredients == true) //물을 넣고 재료를 넣었는가?
                {
                    LimitTime -= Time.deltaTime;
                    Debug.Log(LimitTime); // 시간 UI
                    if (LimitTime >= minTime && LimitTime <= maxTime && (potInteraction.isPotOnInduction == false || inductionButton.isButtonPressed == false) && finsh == false) 
                    {
                        finsh = true;
                        sub_good.gameObject.SetActive(true);
                        //완성 알아서 보글보글 한 후 완성
                    }
                    else if ((LimitTime > maxTime || LimitTime < minTime) && (potInteraction.isPotOnInduction == false || inductionButton.isButtonPressed == false))
                    {
                        //no 탔는지 덜익었는지 ui로 띄운 후 재시작 UI 버튼으로 GameStateLoad2 스크립트 할당하기
                        LimitTime = 10f;
                        sub_fire.gameObject.SetActive(true);
                        sub_retry.gameObject.SetActive(true);
                    }
                }
            }
        }     

        if (table == true)
        {
            sub_end.gameObject.SetActive(true);
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
