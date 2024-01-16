using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobbyManager : MonoBehaviour
{
    public Image WhiteDoor;
    public Image RedDoor;
    public Image BlackBg;
    public Image logo;
    public Animator anim;
    public float FadeTime = 2f; // Fade효과 재생시간
    bool isPlaying = false;

    public AudioSource BgmAS;
    public AudioSource soundAS;
    public AudioClip openDoor;

    public void WhiteDoorBt()
    {
        if(isPlaying==true)
        {
            return;
        }
        else
        {
            soundAS.clip = openDoor;
            soundAS.Play();
            StartCoroutine(WhiteDoorOpen());
        }
    }
    IEnumerator WhiteDoorOpen()
    {
        BgmAS.Stop();
        BlackBg.gameObject.SetActive(true);
        anim.SetTrigger("WhiteDoorClick");
        isPlaying = true;
        yield return new WaitForSeconds(2f);
        Color tempColor = BlackBg.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / FadeTime;
            BlackBg.color = tempColor;

            if (tempColor.a >= 1f) { 
                tempColor.a = 1f;
                //BlackBg.color = tempColor;
                WhiteDoor.gameObject.SetActive(false);
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        logo.gameObject.SetActive(false);
        RedDoor.gameObject.SetActive(true);
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / FadeTime;
            BlackBg.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
                BlackBg.color = tempColor;
            }
            yield return null;
        }
        BlackBg.gameObject.SetActive(false);
        isPlaying = false;
    }
    
}
