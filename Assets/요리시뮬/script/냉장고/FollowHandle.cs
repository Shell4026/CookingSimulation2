using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHandle : MonoBehaviour
{
    public Transform grabable_handle;

    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 to = grabable_handle.position - transform.position;
        body.velocity = to * 5.0f / Time.fixedDeltaTime;
        if (body.velocity.sqrMagnitude < 0.01f)
            body.velocity = Vector3.zero;
        //body.MovePosition(grabable_handle.position);
    }

}
