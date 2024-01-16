using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRoom : MonoBehaviour
{
    public Animator anim;
    public Canvas RobbyCv;
    public Canvas RoomCv;
    public float FadeTime = 2f; // Fade효과 재생시간
    bool isPlaying = false;
    public Image BlackBg;

    public AudioSource SoundAS;
    public AudioClip openDoor;

    public AudioSource BgmAS;
    public AudioClip mainBgm;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void RedDootBt()
    {
        if (isPlaying == true)
        {
            return;
        }
        else
        {
            SoundAS.clip = openDoor;
            SoundAS.Play();
            StartCoroutine(RedDoorOpen());
        }
    }
    IEnumerator RedDoorOpen()
    {
        BlackBg.gameObject.SetActive(true);
        anim.SetTrigger("RedDoorClick");
        isPlaying = true;
        yield return new WaitForSeconds(2f);
        Color tempColor = BlackBg.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / FadeTime;
            BlackBg.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
                //BlackBg.color = tempColor;
                RobbyCv.gameObject.SetActive(false);
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        RoomCv.gameObject.SetActive(true);
        BgmAS.clip = mainBgm;
        BgmAS.Play();
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
