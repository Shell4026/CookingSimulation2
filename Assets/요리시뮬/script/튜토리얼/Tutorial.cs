using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public OVRGrabber[] hands = new OVRGrabber[2];
    public Cookingpreparation manager;

    bool first_grab = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(first_grab)
        {
            if (hands[0].grabbedObject != null || hands[0].grabbedObject != null)
            {
                manager.LevelStart(4);
                first_grab = false;
            }
        }
        
    }
}
