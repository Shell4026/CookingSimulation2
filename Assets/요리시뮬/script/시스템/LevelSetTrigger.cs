using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetTrigger : MonoBehaviour
{
    public Cookingpreparation manager;
    [Header("null이면 플레이어")]
    public Transform target;
    public int require_level = -1;
    public int level;
    public bool once = true;
    public bool is_trigger = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!is_trigger)
            return;

        if (require_level < 0)
            return;

        if (manager.GetLevel() != require_level)
            return;

        if (target == null)
        {
            if (other.CompareTag("Player"))
            {
                manager.LevelStart(level);
                if (once)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if(other.transform == target || other.transform.parent == target)
            {
                manager.LevelStart(level);
                if (once)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (is_trigger)
            return;

        if (require_level < 0)
            return;

        if (manager.GetLevel() != require_level)
            return;

        if (target == null)
        {
            if (collision.transform.CompareTag("Player"))
            {
                manager.LevelStart(level);
                if (once)
                {
                    this.enabled = false;
                }
            }
        }
        else
        {
            if (collision.transform == target || collision.transform.parent == target)
            {
                manager.LevelStart(level);
                if (once)
                {
                    this.enabled = false;
                }
            }
        }
    }
}
