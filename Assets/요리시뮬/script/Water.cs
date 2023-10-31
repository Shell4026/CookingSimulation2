using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Pot pot;
    public bool water = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (pot.water_amount > 0.9f)
        {
            Debug.Log("물이 가득찼습니다. 물을 잠그고 재료를 넣어주세요.");
            water = true;
        }
    }
}
