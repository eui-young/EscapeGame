using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideBManager : MonoBehaviour
{
    public GameObject expandmirror;
    public GameObject down;
    public GameObject blackBg; 
    public GameObject rightBt; 
    public GameObject leftBt; 
    public GameObject lightgame;

    public Image expandBg;
    public AudioSource soundAS;
    public AudioClip rabbitClip;
    // Start is called before the first frame update
    public void MirrorClick()
    {
        StartCoroutine(ObjectCloser());
    }
    public void RabbitClick()
    {
        soundAS.clip = rabbitClip;
        soundAS.Play();
        StartCoroutine(lightGameOn());
    }
    IEnumerator lightGameOn()
    {
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        expandBg.gameObject.SetActive(true);
        lightgame.SetActive(true);
        rightBt.SetActive(false);
        leftBt.SetActive(false);
        down.SetActive(true);
        FadeInOut.fadein = true;
    }
    IEnumerator ObjectCloser()
    {
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        expandmirror.gameObject.SetActive(true);
        rightBt.SetActive(false);
        leftBt.SetActive(false);
        down.SetActive(true);
        DialogMove.dialogcnt = 6;
        DialogMove.dialogup = true;
        FadeInOut.fadein = true;
    }
}
