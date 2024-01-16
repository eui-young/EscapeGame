using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingSideAManager : MonoBehaviour
{
    public GameObject rushHourCv;
    public GameObject clockBg;
    public Image blackBg;
    public Text clearTx;

    public GameObject rightBt;
    public GameObject leftBt;
    public GameObject downBt;

    public Animator anim;

    public AudioSource BgmAS;
    public AudioSource soundAS;
    public AudioClip lockDoor;
    public AudioClip keyDoor;
    public AudioClip openDoor;
    public void RedDoorClick()
    {
        if (Inventory.openTheDoor)
        {
            BgmAS.Stop();
            StartCoroutine(DoorOpen());
        }
        else
        {
            soundAS.clip = lockDoor;
            soundAS.Play();
            DialogMove.dialogcnt = 11;
            DialogMove.dialogup = true;
        }
    }
    public void ClockBtClick()
    {
        if (ClockClear.isHour && ClockClear.isMinute)
            StartCoroutine(WaitTime(rushHourCv));
        else
            StartCoroutine(WaitTime(clockBg));
    }
    IEnumerator WaitTime(GameObject onObject)
    {
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        onObject.SetActive(true);
        rightBt.SetActive(false);
        leftBt.SetActive(false);
        downBt.SetActive(true);
        FadeInOut.fadein = true;
    }

    IEnumerator DoorOpen() 
    {
        soundAS.clip = keyDoor;
        soundAS.Play();
        yield return new WaitForSeconds(2f);
        soundAS.clip = openDoor;
        soundAS.Play();
        anim.SetTrigger("RedDoorClick");
        yield return new WaitForSeconds(2f);
        blackBg.color = new Color(1, 1, 1);
        blackBg.gameObject.SetActive(true);
        clearTx.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
    }
}
