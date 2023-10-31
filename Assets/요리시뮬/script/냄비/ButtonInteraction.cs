using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField]GameObject induction;
    [SerializeField]bool isButtonPressed = false;
    [Header("얼마나 눌러야 하는지")]
    [SerializeField]float press_limit = 0.2f;

    [Space(10.0f)]
    private Color originalColor;
    private Renderer induction_renderer;

    Vector3 original_pos;
    bool pressing = false;

    private void Start()
    {
        induction_renderer = induction.GetComponent<Renderer>();
        originalColor = induction_renderer.material.color;
        original_pos = transform.position;
    }

    public void PressButton()
    {
        isButtonPressed = !isButtonPressed;

        if (isButtonPressed)
        {
            induction_renderer.material.color = Color.red;
        }
        else if (!isButtonPressed)
        {
            induction_renderer.material.color = originalColor;
        }
    }
    protected void FixedUpdate()
    {
        float dis = (transform.position - original_pos).sqrMagnitude;
        if (pressing)
        {
            if(dis < 0.0001f)
            {
                pressing = false;
            }
        }
        else
        {
            if (dis >= press_limit * press_limit)
            {
                PressButton();
                pressing = true;
            }
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
    }
}