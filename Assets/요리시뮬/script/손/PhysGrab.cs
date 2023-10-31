using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysGrab : OVRGrabbable
{
    int original_layer = 0;

    protected override void Start()
    {
        base.Start();
        original_layer = gameObject.layer;
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        gameObject.layer = 9; //Grab tag
    }
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        gameObject.layer = original_layer;
    }
}
