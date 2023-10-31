using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] Cookingpreparation manager;
    [SerializeField] GameObject induction;
    [SerializeField] bool isButtonPressed = false;
    [Header("눌리기 위한 최소 속력")]
    [SerializeField] float min_speed = 0.3f;

    Animator anim;

    Color originalColor;
    Renderer induction_renderer;

    bool first = true;

    private void Start()
    {
        induction_renderer = induction.GetComponent<Renderer>();
        originalColor = induction_renderer.material.color;
        anim = GetComponent<Animator>();
    }

    public void PressButton()
    {
        isButtonPressed = !isButtonPressed;

        if (isButtonPressed)
        {
            if(first)
            {
                manager.LevelStart(12);
                first = false;
            }
            anim.SetBool("press", true);
            induction_renderer.material.color = Color.red;
        }
        else if (!isButtonPressed)
        {
            anim.SetBool("press", false);
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.velocity.magnitude > min_speed)
        {
            PressButton();
        }
    }
}