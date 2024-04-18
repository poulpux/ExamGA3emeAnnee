using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SwitchBeetweenColors : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public float lerpDuration = 1f;

    SpriteRenderer rendererr;


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
        rendererr = GetComponent<SpriteRenderer>();
        StartCoroutine(StartColorLerp());
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
