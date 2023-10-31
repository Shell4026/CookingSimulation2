using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject watermin;
    public GameObject watermax;
    public Pot pot;
    public bool water = false;
    public bool finsh = false;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (pot.water_amount > 0.9f && finsh == true)
        {
            watermax.SetActive(true);
            water = true;
        }
        else if(pot.water_amount < 0.9f && finsh == false)
        {
            watermin.SetActive(true);
            finsh = true;
        }
    }
}
