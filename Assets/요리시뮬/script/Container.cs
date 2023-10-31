using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    Dictionary<GameObject, Transform> objs = new();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (!objs.ContainsKey(collision.gameObject))
            return;
        
        collision.transform.parent = objs[collision.gameObject];
        Debug.Log(collision.gameObject.name);
        objs.Remove(collision.gameObject);
    }
}
