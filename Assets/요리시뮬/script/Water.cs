using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Pot pot;

    private void Start()
    {
        pot = GetComponent<Pot>();
    }

    private void Update()
    {
        if (pot.water_amount > 0.9f)
        {
            Debug.Log("물이 가득찼습니다. 물을 잠그고 재료를 넣어주세요.");
        }
    }
}
