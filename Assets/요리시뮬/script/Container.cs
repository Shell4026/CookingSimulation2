using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Container : MonoBehaviour
{
    Dictionary<GameObject, Transform> objs = new();

    Rigidbody my_rig;

    void Start()
    {
        my_rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
        if (grab == null)
            obj.transform.parent = objs[obj];
        else
        {
            if (grab.isGrabbed == true)
            {
                obj.transform.parent = grab.grabbedBy.transform;
            }
            else
                obj.transform.parent = objs[obj];
        }

        objs.Remove(obj);

        var cutable = obj.GetComponentInParent<Cutable>();
        if (cutable != null)
            cutable.SetContainer(null);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
            return;
        Vector3 normal = collision.GetContact(0).normal;
        float dot = Vector3.Dot(normal, Vector3.down);
        if (dot > 0.966)
        {
            AddObject(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        RemoveObject(collision.gameObject);
    }
}
