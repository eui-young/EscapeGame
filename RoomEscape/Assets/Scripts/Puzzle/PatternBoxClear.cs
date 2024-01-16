using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternBoxClear : MonoBehaviour
{
    public static bool[] isPatternBoxClear;
    public static bool getKey1;
    public static bool getBond;

    public GameObject patternBox;
    public Image boxImg;
    public Sprite boxOpenSprite;
    public Image blackBg;
    public Image blind;
    public GameObject rightBt;
    public GameObject leftBt;
    public GameObject downBt;
    public GameObject exandBg;
    public GameObject key1;
    public GameObject bond;
    private bool isOne = true;

    public AudioSource soundAS;
    public AudioClip unlock;
    public AudioClip openBoxClip;
    private void Awake()
    {
        isPatternBoxClear = new bool[4];
    }
    void Update()
    {
        if (isOne && isPatternBoxClear[0] && isPatternBoxClear[1] && isPatternBoxClear[2] && isPatternBoxClear[3])
        {
            StartCoroutine(CoFadeIn());
            getKey1 = true;
            getBond = true;
            isOne = false;
        }
    }
    IEnumerator CoFadeIn()
    {
        soundAS.clip = unlock;
        soundAS.Play();
        yield return new WaitForSeconds(1f);
        soundAS.clip = openBoxClip;
        soundAS.Play();
        boxImg.sprite = boxOpenSprite;
        yield return new WaitForSeconds(1f);
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        exandBg.SetActive(true);
        key1.SetActive(true);
        bond.SetActive(true);
        downBt.SetActive(true);
        rightBt.SetActive(true);
        leftBt.SetActive(true);
        blind.gameObject.SetActive(true);
        patternBox.gameObject.SetActive(false);
        DialogMove.dialogup = true;
        DialogMove.dialogcnt = 17;
        FadeInOut.fadein = true;
    }
}
