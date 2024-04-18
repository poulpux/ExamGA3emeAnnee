using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class SwitchBeetweenColorsLight : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public float lerpDuration = 1f;

    Light2D rendererr;


    IEnumerator StartColorLerp()
    {
        float timeElapsed = 0f;
        Color currentColor = startColor;

        while (true)
        {
            while (timeElapsed < lerpDuration)
            {
                timeElapsed += Time.deltaTime;
                float t = timeElapsed / lerpDuration;
                currentColor = Color.Lerp(startColor, endColor, t);
                rendererr.color = currentColor;
                yield return null;
            }

            Color temp = startColor;
            startColor = endColor;
            endColor = temp;
            timeElapsed = 0f;
        }
    }

    void Start()
    {
        rendererr = GetComponent<Light2D>();
        StartCoroutine(StartColorLerp());
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
