using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberBoxClear : MonoBehaviour
{
    public static bool[] isNumberBoxClear;
    public static bool getDeskKey;

    public GameObject numberBoxBg;
    public Image boxImg;
    public Image blackBg;
    public Image blind;
    public Sprite boxOpenSprite;

    public GameObject exandBg;
    public GameObject deskKey;
    public GameObject downBt;
    public GameObject rightBt;
    public GameObject leftBt;

    private bool isOne=true;

    public AudioSource soundAS;
    public AudioClip unLock;
    public AudioClip boxOpen;

    private void Awake()
    {
        isNumberBoxClear = new bool[4];
    }
    void Update()
    {
        if (isOne&&isNumberBoxClear[0] && isNumberBoxClear[1] && isNumberBoxClear[2] && isNumberBoxClear[3])
        {
            StartCoroutine(CoFadeIn());
            getDeskKey = true;
            isOne = false;
        }
    }
    IEnumerator CoFadeIn()
    {
        soundAS.clip = unLock;
        soundAS.Play();
        yield return new WaitForSeconds(1f);
        boxImg.sprite = boxOpenSprite;
        soundAS.clip = boxOpen;
        soundAS.Play();
        yield return new WaitForSeconds(1f);
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        exandBg.SetActive(true);
        deskKey.SetActive(true);
        downBt.SetActive(true);
        rightBt.SetActive(true);
        leftBt.SetActive(true);
        blind.gameObject.SetActive(true);
        numberBoxBg.gameObject.SetActive(false);
        DialogMove.dialogup = true;
        DialogMove.dialogcnt = 14;
        FadeInOut.fadein = true;
    }
}
