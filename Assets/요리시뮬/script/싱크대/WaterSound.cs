using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WaterSound : MonoBehaviour
{
    private AudioSource audios;

    bool off = false;
    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audios = GetComponent<AudioSource>();
        audios.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (!off)
        {
            if (audios.isPlaying)
            {
                if (audios.time > 10.0f)
                    audios.time -= 5.0f;
            }
        }
        else
        {
            if(!audios.isPlaying)
            {
                off = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void On()
    {
        if (audios != null)
            audios = GetComponent<AudioSource>();
        off = false;
        audios.time = 0.0f;
        audios.Play();
    }

    public void Off()
    {
        if (audios != null)
            audios = GetComponent<AudioSource>();
        off = true;
        audios.time = 96.5f;
    }
}
