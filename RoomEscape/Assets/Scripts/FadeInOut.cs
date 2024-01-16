using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image BlackBg;
    bool isPlaying = false;
    public static bool fadeout;
    public static bool fadein;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if(fadeout==true&&isPlaying==false)
        {
            StartCoroutine(FadeOut());
        }
        else if(fadeout==false&&fadein==true)
        {
            StartCoroutine(FadeIn());
        }
    }
    IEnumerator FadeOut()
    {
        //yield return new WaitForSeconds(1f);
        BlackBg.gameObject.SetActive(true);
        isPlaying = true;
        Color tempColor = BlackBg.color;
        tempColor.a = 0f;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / 0.8f;
            BlackBg.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
                //BlackBg.color = tempColor;
            }
            yield return null;
        }
        fadeout = false;
    }
    IEnumerator FadeIn()
    {
        Color tempColor = BlackBg.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / 0.8f;
            BlackBg.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
                BlackBg.color = tempColor;
            }
            yield return null;
        }
        BlackBg.gameObject.SetActive(false);
        fadein = false;
        isPlaying = false;
    }
}
