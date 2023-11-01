using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] Cookingpreparation manager;
    [SerializeField] GameObject induction;
    [SerializeField] bool isButtonPressed = false;
    [SerializeField] GameObject button;
    [SerializeField] float push_dis = 0.1f;

    Vector3 original_pos;

    Color originalColor;
    Renderer induction_renderer;

    bool first = true;
    bool wait = false;

    private void Start()
    {
        induction_renderer = induction.GetComponent<Renderer>();
        originalColor = induction_renderer.material.color;
        original_pos = button.transform.position;
    }

    public void PressButton()
    {
        isButtonPressed = !isButtonPressed;

        if (isButtonPressed)
        {
            if(first)
            {
                if (manager.GetLevel() >= 11)
                {
                    manager.LevelStart(12);
                    first = false;
                }
            }
            induction_renderer.material.color = Color.red;
        }
        else
        {
            induction_renderer.material.color = originalColor;
        }
    }

    public void SetPress(bool p)
    {
        isButtonPressed = p;
    }
    public bool IsPress()
    {
        return isButtonPressed;
    }

    private void FixedUpdate()
    {
        float dis = (button.transform.position - original_pos).sqrMagnitude;
        //Debug.Log((button.transform.position - original_pos).magnitude);
        if (!wait)
        {
            
            if (dis > push_dis * push_dis)
            {
                PressButton();
                wait = true;
            }
        }
        else
        {
            if (dis < 0.0001f)
                wait = false;
        }

    }
}