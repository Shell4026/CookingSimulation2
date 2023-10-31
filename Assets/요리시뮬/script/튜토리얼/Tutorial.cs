using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public OVRGrabber[] hands = new OVRGrabber[2];
    public Cookingpreparation manager;

    bool first_grab = true;
    bool first_grab_egg = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(first_grab)
        {
            if (hands[0].grabbedObject != null || hands[1].grabbedObject != null)
            {
                manager.LevelStart(4);
                first_grab = false;
            }
        }
        if (first_grab_egg)
        {
            if (manager.GetLevel() > 8)
            {
                OVRGrabbable obj = hands[0].grabbedObject;
                if(obj.gameObject.name.Contains("egg"))
                {
                    manager.LevelStart(10);
                    first_grab_egg = false;
                }
                obj = hands[1].grabbedObject;
                if (obj.gameObject.name.Contains("egg"))
                {
                    manager.LevelStart(10);
                    first_grab_egg = false;
                }
            }
        }
    }
}
