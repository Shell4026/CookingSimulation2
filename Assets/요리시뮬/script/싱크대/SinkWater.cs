using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SinkWater : MonoBehaviour
{
    public WaterSound water_sound;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void On()
    {
        anim.SetInteger("state", 1);
        if (water_sound != null)
        {
            water_sound.gameObject.SetActive(true);
            water_sound.On();
        }
    }
    public void Off()
    {
        anim.SetInteger("state", 2);
        if (water_sound != null)
            water_sound.Off();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SinkWater))]
public class SinkWaterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        this.DrawDefaultInspector();

        GUILayout.Space(10.0f);
        GUILayout.Label("Å×½ºÆ®");
        GUI.enabled = Application.isPlaying;
        if(GUILayout.Button("On"))
        {
            SinkWater s = (SinkWater)target;
            s.On();
        }
        if (GUILayout.Button("Off"))
        {
            SinkWater s = (SinkWater)target;
            s.Off();
        }
        GUI.enabled = true;
    }
}
#endif