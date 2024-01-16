using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedClockClear : MonoBehaviour
{
    public static bool isBedHour;
    public static bool isBedMinute;
    public static bool getRestroomKey;

    public Image clockBg;
    public Image blackBg;

    public GameObject rightBt;
    public GameObject leftBt;
    public GameObject downBt;

    public GameObject exandBg;
    public GameObject restroomKey;

    private bool isOne = true;

    public AudioSource soundAS;
    public AudioClip clockClearClip;
    private void Update()
    {
        if (isOne && isBedHour && isBedMinute)
        {
            soundAS.clip = clockClearClip;
            soundAS.Play();
            StartCoroutine(outPuzzle());
            getRestroomKey = true;
            isOne = false;
        }
    }
    IEnumerator outPuzzle()
    {
        yield return new WaitForSeconds(1f);
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        clockBg.gameObject.SetActive(false);
        exandBg.SetActive(true);
        restroomKey.SetActive(true);
        rightBt.SetActive(true);
        leftBt.SetActive(true);
        downBt.SetActive(true);
        DialogMove.dialogcnt = 18;
        DialogMove.dialogup = true;
        FadeInOut.fadein = true;
    }
}
