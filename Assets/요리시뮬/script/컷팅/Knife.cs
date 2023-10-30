using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Transform center;
    public Transform normal;
    public AudioSource audios;

    float speed = 0.0f;
    Vector3 before_center;
    void Start()
    {
        before_center = center.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        speed = (center.position - before_center).sqrMagnitude;
        before_center = center.position;
    }
    public Vector3 GetKnifeNormal()
    {
        return (normal.position - center.position).normalized;
    }

    public float GetSqrSpeed()
    {
        return speed;
    }
}
