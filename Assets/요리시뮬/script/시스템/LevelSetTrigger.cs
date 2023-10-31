using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetTrigger : MonoBehaviour
{
    public Cookingpreparation manager;
    public int require_level = -1;
    public int level;
    public bool once = true;
    private void OnTriggerEnter(Collider other)
    {
        if (require_level < 0)
            return;

        if (manager.GetLevel() != require_level)
            return;

        if(other.CompareTag("Player"))
        {
            manager.LevelStart(level);
            if(once)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
