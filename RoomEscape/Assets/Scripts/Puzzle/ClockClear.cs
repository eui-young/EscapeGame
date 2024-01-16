using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockClear : MonoBehaviour
{
    public static bool isHour;
    public static bool isMinute;

    public GameObject rushHourCv;
    public Image clockBg;
    public Image blackBg;

    public GameObject rightBt;
    public GameObject leftBt;
    public GameObject downBt;

    public AudioSource soundAS;
    public AudioClip clockClear;

    private bool isOne=true;
    private void Update()
    {
        if (isOne&&isHour && isMinute)
        {
            StartCoroutine(miniGameOn());
            soundAS.clip = clockClear;
            soundAS.Play();
            isOne = false;
        }
    }
    IEnumerator miniGameOn()
    {
        yield return new WaitForSeconds(1f);
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        rushHourCv.SetActive(true);
        clockBg.gameObject.SetActive(false);
        rightBt.SetActive(false);
        leftBt.SetActive(false);
        downBt.SetActive(true);
        FadeInOut.fadein = true;
    }
}
