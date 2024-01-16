using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SideCManager : MonoBehaviour
{
    public GameObject down;
    public Sprite opencloset;
    public Image closet;
    public Image desk;
    public Image opendesk;
    public static bool useclosetkey;
    int cnt;
    public GameObject expandbg;
    public GameObject expandpaper;
    public static bool usedeskkey;

    public AudioSource soundAS;
    public AudioClip lockObject;
    public AudioClip paper;
    public AudioClip openDeskClip;
    public AudioClip openClosetClip;

    public Image blackBg;
    public Image expandBg;
    public GameObject cardGame;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
    }

    // Update is called once per frame
    public void closetClick()
    {
        if(cnt==0)
        {
            soundAS.clip = lockObject;
            soundAS.Play();
            DialogMove.dialogcnt = 8;
            DialogMove.dialogup = true;
        }

        if(Inventory.opencloset==true&&cnt==0)
        {
            soundAS.clip = openClosetClip;
            soundAS.Play();
            closet.sprite = opencloset;
            cnt =1;
            DialogMove.dialogcnt = 9;
            DialogMove.dialogup = true;
            useclosetkey = true;
        }
        else if(cnt==1)
        {
            soundAS.clip = paper;
            soundAS.Play();
            expandbg.SetActive(true);
            expandpaper.SetActive(true);
            down.SetActive(true);
        }
    }
    public void deskClick()
    {
        if (CardGame1.getKey2 == true)
        {
            DialogMove.dialogcnt = 20;
            DialogMove.dialogup = true;
        }
        else
        {
            DialogMove.dialogcnt = 10;
            DialogMove.dialogup = true;
        }
    }
    public void deskbottom()
    {
        if (NumberBoxClear.getDeskKey == true&&Inventory.opendesk==true)
        {
            soundAS.clip = openDeskClip;
            soundAS.Play();
            desk.gameObject.SetActive(false);
            opendesk.gameObject.SetActive(true);
            DialogMove.dialogcnt = 22;
            DialogMove.dialogup = true;
            usedeskkey = true;
        }
        else
        {
            soundAS.clip = lockObject;
            soundAS.Play();
            DialogMove.dialogcnt = 21;
            DialogMove.dialogup = true;
        }
    }
    public void cardClick()
    {
        StartCoroutine(cardGameOn());
    }
    IEnumerator cardGameOn()
    {
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        expandBg.gameObject.SetActive(true);
        cardGame.SetActive(true);
        FadeInOut.fadein = true;
    }
}
