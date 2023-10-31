using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWater : MonoBehaviour
{
    [Header("물줄기 태그")]
    public string water_tag;
    [Header("냄비")]
    public Pot pot;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(water_tag))
        {
            pot.Fill();
        }
    }
}
