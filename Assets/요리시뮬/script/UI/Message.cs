using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message : FollowingUI
{
    [Header("사라지는 시간")]
    public float life_time = 3.0f;
    public float fade_time = 1.0f;
    [Header("렌더러")]
    public MeshRenderer render;
    public Text text;
    public TextMeshProUGUI textpro;

    float time = 0.0f;
    bool start_fade = false;
    protected override void Start()
    {
        base.Start();
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (start_fade)
            return;
        if(time >= life_time)
        {
            start_fade = true;
            StartCoroutine("Fade");
        }
        else
            time += Time.deltaTime;
    }
    public IEnumerator Fade()
    {
        Color c = new();
        if (render != null)
            c = render.material.color;
        if (text != null)
            c = text.color;
        if (textpro != null)
            c = textpro.color;

        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            if (f < 0.1)
            {
                time = 0.0f;
                start_fade = false;
                c.a = 1.0f;
                if (render != null)
                    render.material.color = c;
                if (text != null)
                    text.color = c;
                if (textpro != null)
                    textpro.color = c;
                gameObject.SetActive(false);
                yield return null;
            }
            c.a = f;
            if(render != null)
                render.material.color = c;
            if(text != null)
                text.color = c;
            if (textpro != null)
                textpro.color = c;
            yield return new WaitForSeconds(fade_time / 100.0f);
        }
    }
}
