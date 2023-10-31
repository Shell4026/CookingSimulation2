using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float followSpeed = 5.0f; // 따라가기 속도
    public Transform targetCamera;

    void Update()
    {
        if (targetCamera != null)
        {
            transform.rotation = Quaternion.Euler(0, targetCamera.localEulerAngles.y, 0);
            // 카메라의 위치를 따라가도록 설정
            transform.position = Vector3.Lerp(transform.position, targetCamera.position, followSpeed * Time.deltaTime);
        }
    }
}
