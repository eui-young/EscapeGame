using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingSideDManager : MonoBehaviour
{
    public static bool useRestroomKey;

    public Animator anim;
    public GameObject livingroom;
    public GameObject restroom;
    public Image blackBg;

    public Image curtain;
    public Sprite curtainOpenSp;
    public Sprite curtainCloseSp;
    public Image blind;

    public Image boxBg;
    public GameObject rightBt;
    public GameObject leftBt;
    public GameObject downBt;

    public AudioSource soundAS;
    public AudioClip curtainClip;
    public AudioClip lockDoor;
    public AudioClip keyDoor;
    public AudioClip openDoor;

    private bool isOpen;
    public void BoxClick()
    {
        StartCoroutine(boxCloser());
    }
    public void sofaClick()
    {
        DialogMove.dialogcnt = 16;
        DialogMove.dialogup = true;
    }
    public void CurtainClick()
    {
        if (curtain.sprite == curtainOpenSp)
            curtain.sprite = curtainCloseSp;
        else
        {
            if (blind.gameObject.activeSelf == false)
            {
                DialogMove.dialogcnt = 28;
                DialogMove.dialogup = true;
            }
            curtain.sprite = curtainOpenSp;
        }

        soundAS.clip = curtainClip;
        soundAS.Play();
    }
    public void WhiteDoorClick()
    {
        if (Inventory.openRestroom&&BedClockClear.getRestroomKey || isOpen)
        {
            StartCoroutine(openWhiteDoor());
            isOpen =true;
            DirectionButton.isRest = true;
            DirectionButton.isLiving = false;
            useRestroomKey = true;
        }
        else
        {
            soundAS.clip = lockDoor;
            soundAS.Play();
            DialogMove.dialogcnt = 15;
            DialogMove.dialogup = true;
        }
    }
    IEnumerator openWhiteDoor()
    {
        if (!isOpen)
        {
            soundAS.clip = keyDoor;
            soundAS.Play();
            yield return new WaitForSeconds(2f);
        }
        soundAS.clip = openDoor;
        soundAS.Play();
        anim.SetTrigger("WhiteDoorClick");
        blackBg.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        livingroom.SetActive(false);
        restroom.SetActive(true);
        FadeInOut.fadein = true;
        anim.SetTrigger("WhiteDoorIdle");
    }
    IEnumerator boxCloser()
    {
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        boxBg.gameObject.SetActive(true);
        rightBt.SetActive(false);
        leftBt.SetActive(false);
        downBt.SetActive(true);
        FadeInOut.fadein = true;
    }
}
