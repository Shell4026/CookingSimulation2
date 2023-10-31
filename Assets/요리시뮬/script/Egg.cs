using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject white_egg_prefab;
    OVRGrabbable grab;
    void Start()
    {
        grab = GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        if (grab == null)
            return;
        if (grab.isGrabbed)
        {
            if (OVRInput.Get(OVRInput.RawButton.A) || OVRInput.Get(OVRInput.RawButton.X))
            {
                if (white_egg_prefab == null)
                    return;
                GameObject obj = Instantiate(white_egg_prefab);
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                Destroy(gameObject);
            }
        }
    }
}
