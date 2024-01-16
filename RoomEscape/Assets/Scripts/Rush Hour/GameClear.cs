using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public static bool isRHClear;
    public static bool getKey3=false; //열쇠조각3

    public GameObject rushHourCv;
    public Image blindImg;
    public GameObject rightBt;
    public GameObject leftBt;
    public GameObject downBt;

    public GameObject expandBg;
    public GameObject key3;

    public AudioSource soundAS;
    public AudioClip gameClear;

    private Color fadeColor;
    private bool isOne=true;

    private void Awake()
    {
        fadeColor = blindImg.color;
    }
    private void OnEnable()
    {
        FadeIn(1f);
    }
    private void Update()
    {
        if (isRHClear&&isOne)
        {
            FadeOut(2f);
            soundAS.clip = gameClear;
            soundAS.Play();
            isOne = false;
        }
    }
    public void OutBtClick()
    {
        blindImg.gameObject.SetActive(true);
        FadeOut(1f);
    }
    private void GetItem()
    {
        getKey3 = true;
        expandBg.SetActive(true);
        key3.SetActive(true);
        downBt.SetActive(true);
        DialogMove.dialogup = true;
        DialogMove.dialogcnt = 12;
    }
    private void FadeOut(float fadeOutTime)
    {
        StartCoroutine(CoFadeOut(fadeOutTime));
    }
    private void FadeIn(float fadeInTime)
    {
        StartCoroutine(CoFadeIn(fadeInTime));
    }
    IEnumerator CoFadeOut(float fadeOutTime)
    {
        while (fadeColor.a < 1f)
        {
            fadeColor.a += Time.deltaTime / fadeOutTime;
            blindImg.color = fadeColor;

            if (fadeColor.a >= 1f) fadeColor.a = 1f;

            yield return null;
        }
        rushHourCv.SetActive(false);
        rightBt.SetActive(true);
        leftBt.SetActive(true);
        downBt.SetActive(false);
        if(isRHClear&&getKey3==false)
            GetItem();
    }
    IEnumerator CoFadeIn(float fadeOutTime)
    {
        while (fadeColor.a > 0f)
        {
            fadeColor.a -= Time.deltaTime / fadeOutTime;
            blindImg.color = fadeColor;

            if (fadeColor.a <= 0f) fadeColor.a = 0f;

            yield return null;
        }
        blindImg.gameObject.SetActive(false);
    }
}
