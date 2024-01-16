using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingSideBManager : MonoBehaviour
{
    public Animator anim;
    public GameObject livingroom;
    public GameObject bedroom;
    public Image blackBg;

    public Image curtain;
    public Sprite curtainCloseSp;
    public Sprite curtainOpenSp;

    public Image shelf;
    public Sprite shelfOpenSP;

    public Image expandBg;
    public Image paper;
    public Image blind;

    public GameObject downBt;

    public AudioSource soundAS;
    public AudioClip curtainClip;
    public AudioClip shelfClip;
    public AudioClip doorOpenClip;
    public AudioClip paperClip;
    public void ShelfClick()
    {
        if (shelf.sprite == shelfOpenSP)
        {
            soundAS.clip = paperClip;
            soundAS.Play();
            downBt.SetActive(true);
            expandBg.gameObject.SetActive(true);
            paper.gameObject.SetActive(true);
            DialogMove.dialogcnt = 13;
            DialogMove.dialogup = true;
        }
        else
        {
            soundAS.clip = shelfClip;
            soundAS.Play();
            shelf.sprite = shelfOpenSP;
        }
    }
    public void CurtainClick()
    {
        if (curtain.sprite == curtainOpenSp)
            curtain.sprite = curtainCloseSp;
        else
        {
            if (blind.gameObject.activeSelf == false)
            {
                DialogMove.dialogup = true;
                DialogMove.dialogcnt = 27;
            }
            curtain.sprite = curtainOpenSp;
        }

        soundAS.clip = curtainClip;
        soundAS.Play();
    }
    public void BlackDoorClick()
    {
        soundAS.clip = doorOpenClip;
        soundAS.Play();
        StartCoroutine(WaitTime());
    }
    IEnumerator WaitTime()
    {
        DirectionButton.isLiving = false;
        DirectionButton.isBed = true;
        anim.SetTrigger("BlackDoorClick");
        yield return new WaitForSeconds(2f);
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        livingroom.SetActive(false);
        bedroom.SetActive(true);
        FadeInOut.fadein = true;
        anim.SetTrigger("BlackDoorIdle");
    }
}
