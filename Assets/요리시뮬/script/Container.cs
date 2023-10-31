using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Container : MonoBehaviour
{
    Dictionary<GameObject, Transform> objs = new();

    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("knife"))
        {
            if(rigidbody.velocity.sqrMagnitude < 0.1)
                rigidbody.isKinematic = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();
        if(rigid != null)
        {
            if(rigid.velocity.sqrMagnitude < 0.1f)
            {
                if(!objs.ContainsKey(collision.gameObject))
                {
                    objs.Add(collision.gameObject, collision.transform.parent);
                    collision.transform.parent = transform;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("knife"))
            rigidbody.isKinematic = false;

        if (!objs.ContainsKey(collision.gameObject))
            return;
        
        collision.transform.parent = objs[collision.gameObject];
        Debug.Log(collision.gameObject.name);
        objs.Remove(collision.gameObject);
    }
}
