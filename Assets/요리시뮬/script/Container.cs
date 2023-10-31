using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Container : MonoBehaviour
{
    OVRGrabbable m_grab;

    Dictionary<GameObject, Transform> objs = new();
    void Start()
    {
        m_grab = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var hand_rig = m_grab.grabbedBy.GetComponent<Rigidbody>();
        foreach(var i in objs)
        {
            Rigidbody rb = i.Key.GetComponentInChildren<Rigidbody>();
            rb.AddForce(hand_rig.velocity);
            Vector3 force = hand_rig.velocity;
            Debug.LogFormat("{0}, {1}, {2}", force.x, force.y, force.z);
        }
    }
    void Update()
    {
        
    }

    public void AddObject(GameObject obj)
    {
        if (!objs.ContainsKey(obj))
        {
            objs.Add(obj, transform.parent);
            obj.transform.parent = transform;
        }
        var cutable = obj.GetComponentInParent<Cutable>();
        if (cutable != null)
            cutable.SetContainer(this);
    }

    public void RemoveObject(GameObject obj)
    {
        if (!objs.ContainsKey(obj))
            return;

        OVRGrabbable grab = obj.GetComponentInParent<OVRGrabbable>();
        if (grab.isGrabbed == true)
        {
            obj.transform.parent = grab.grabbedBy.transform;
        }
        else
            obj.transform.parent = null;

        obj.layer = 0;
        obj.GetComponentInChildren<Collider>().gameObject.layer = 0;

        objs.Remove(obj);

        var cutable = obj.GetComponentInParent<Cutable>();
        if (cutable != null)
            cutable.SetContainer(null);
    }

    private void OnCollisionStay(Collision collision)
    {
        var grab = collision.gameObject.GetComponentInParent<OVRGrabbable>();
        if (grab == null || collision.gameObject.CompareTag("knife"))
            return;

        if (grab.isGrabbed)
        {
            RemoveObject(collision.gameObject);
            return;
        }

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
            return;

        if (rb.velocity.sqrMagnitude < 0.1f)
        {
            Vector3 normal = collision.GetContact(0).normal;
            float dot = Vector3.Dot(normal, Vector3.down);
            if (dot > 0.966f)
            {
                AddObject(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        var grab = collision.gameObject.GetComponentInParent<OVRGrabbable>();
        if (grab == null)
            return;
        RemoveObject(collision.gameObject);
    }
}
