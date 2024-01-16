using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoManager : MonoBehaviour
{
    public Image logo;
    private Color fadeColor;
    private void Awake()
    {
        fadeColor = logo.color;
        StartCoroutine(CoFadeOut(2.5f));
    }
    private void Update()
    {
        logo.transform.localPosition = Vector2.MoveTowards(new Vector2(logo.transform.localPosition.x, logo.transform.localPosition.y), new Vector2(20, 315), 1f);
    }
    IEnumerator CoFadeOut(float fadeOutTime)
    {
        while (fadeColor.a < 1f)
        {
            fadeColor.a += Time.deltaTime / fadeOutTime;
            logo.color = fadeColor;

            if (fadeColor.a >= 1f) fadeColor.a = 1f;

            yield return null;
        }
    }
}
