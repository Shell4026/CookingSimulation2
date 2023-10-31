using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingUI : MonoBehaviour
{
    [Header("플레이어와의 거리")]
    public float distance = 2.0f;
    [Header("플레이어 카메라")]
    public Transform player_cam;
    [Header("따라오는 속도")]
    public float max_speed = 3.0f;
    private void Start()
    {
        
    }
    void Update()
    {
        Vector3 goal = player_cam.position + player_cam.forward * distance;
        float goal_dis = (goal - transform.position).magnitude;

        transform.rotation = Quaternion.Slerp(transform.rotation, player_cam.transform.rotation, goal_dis * max_speed * Time.deltaTime);
        //transform.position += goal * max_speed * Time.deltaTime; //2번째 방법
        transform.position = Vector3.Slerp(transform.position, goal, goal_dis * max_speed * Time.deltaTime);
    }
}
