using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Container : MonoBehaviour
{
    public float break_force = 15;
    public Rigidbody m_rb;
    void Start()
    {
    }

    private void OnCollisionStay(Collision collision)
    {
        var grab = collision.gameObject.GetComponentInParent<OVRGrabbable>();
        if (grab == null || collision.gameObject.CompareTag("knife"))
            return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
            return;

        if (rb.velocity.sqrMagnitude < 0.1f)
        {
            Vector3 normal = collision.GetContact(0).normal;
            float dot = Vector3.Dot(normal, Vector3.down);
            if (dot > 0.966f)
            {
                if (collision.gameObject.GetComponent<FixedJoint>() == null)
                {
                    var joint = collision.gameObject.AddComponent<FixedJoint>();
                    joint.breakForce = break_force;
                    joint.connectedBody = m_rb;
                }
                //AddObject(collision.gameObject);
            }
        }
    }
}
