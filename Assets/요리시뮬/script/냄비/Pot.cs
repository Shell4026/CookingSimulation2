using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private float water_amount = 0.0f;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fill()
    {
        if(water_amount < 1.0f)
        {
            water_amount += 0.1f * Time.deltaTime;
            anim.SetFloat("water", water_amount);
        }
    }

    public void SetWaterAmount(float amount)
    {
        if (amount > 1.0f)
            amount = 1.0f;
        if (amount < 0.0f)
            amount = 0.0f;
        water_amount = amount;
    }
    public float GetWaterAmount()
    {
        return water_amount;
    }
}
