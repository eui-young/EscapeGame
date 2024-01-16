using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideAManager : MonoBehaviour
{
    public Image shelf;
    public Image candle1;
    public Image candle2;
    public Image shelfTop;
    public Image expandFrame;
    public Sprite shelf2;
    public Sprite candleoff;
    public Sprite candleon;
    public Sprite paper1;
    public Image expandPaper1;
    public GameObject expandClosetKey;
    public GameObject down;
    public Image blackbg;
    public GameObject livingroom; //
    public GameObject bedroom; //
    public Image fadeImg; //
    public GameObject rightBt; //
    public GameObject leftBt; //

    public Animator anim;
    int shelfCount;
    public static bool getclosetkey; //옷장열쇠를 얻었는지 확인
    public static bool useshelfkey;
    bool []candle=new bool[2];
    float dialogy;

    public AudioSource soundAS;
    public AudioClip candleOn;
    public AudioClip candleOff;
    public AudioClip openDoor;
    public AudioClip lockObject;
    public AudioClip paperClip;
    void Start()
    {
        shelfCount = 0;
        candle[0] = false;
        candle[1] = false;
    }
    public void shelfClick1() //선반 클릭시
    {
        if(shelfCount==0)
        {
            if(Inventory.openshelf)
            {
                useshelfkey = true;
                DialogMove.dialogcnt = 0;
                DialogMove.dialogup = true;
                shelf.sprite = shelf2;
                shelfCount += 1;
            }
            else
            {
                DialogMove.dialogcnt = 24;
                DialogMove.dialogup = true;
                soundAS.clip = lockObject;
                soundAS.Play();
            }
        }
        else
        {
            soundAS.clip = paperClip;
            soundAS.Play();
            expandPaper1.sprite = paper1;
            blackbg.gameObject.SetActive(true);
            expandPaper1.gameObject.SetActive(true);
            down.SetActive(true);
        }
    }
    public void Candle1Click()//첫번째 양초 클릭시
    {
        if(candle[0]==true)
        {
            soundAS.clip = candleOff;
            soundAS.Play();
            candle[0] = false;
            candle1.sprite = candleoff;
            useshelfkey = true;
        }
        else
        {
            soundAS.clip = candleOn;
            soundAS.Play();
            candle[0] = true;
            candle1.sprite = candleon;
        }
        if(candle[0]==true&&candle[1]==true)
        {
            if (getclosetkey == false)
            {
                DialogMove.dialogcnt = 1;
                DialogMove.dialogup = true;
            }
            shelfTop.gameObject.SetActive(true);
        }
    } 
    public void Candle2Click()//두번째 양초 클릭시
    {
        if (candle[1] == true)
        {
            soundAS.clip = candleOff;
            soundAS.Play();
            candle[1] = false;
            candle2.sprite = candleoff;
        }
        else
        {
            soundAS.clip = candleOn;
            soundAS.Play();
            candle[1] = true;
            candle2.sprite = candleon;
        }
        if (candle[0] == true && candle[1] == true)
        {
            if (getclosetkey ==false) 
            {
                DialogMove.dialogcnt = 1;
                DialogMove.dialogup = true;
            }
            shelfTop.gameObject.SetActive(true);
        }
    } 
    public void ShelfTopClick() //선반 위 클릭
    {
        if ( getclosetkey == false)
        {
            blackbg.gameObject.SetActive(true);
            expandClosetKey.gameObject.SetActive(true);
            DialogMove.dialogcnt = 2;
            DialogMove.dialogup = true;
            down.gameObject.SetActive(true);
            getclosetkey = true;
        }
    }
    public void BedClick()
    {
        DialogMove.dialogcnt = 3;
        DialogMove.dialogup = true;
    }
    public void RedDoorClick()
    {
        soundAS.clip = openDoor;
        soundAS.Play();
        StartCoroutine(WaitTime());
    }
    public void FrameClick()
    {
        StartCoroutine(ObjectCloser()); //
        /*expandFrame.gameObject.SetActive(true);
        down.gameObject.SetActive(true);
        DialogMove.dialogcnt = 5;
        DialogMove.dialogup = true;*/
    }
    IEnumerator ObjectCloser() //
    {
        fadeImg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        expandFrame.gameObject.SetActive(true);
        rightBt.SetActive(false);
        leftBt.SetActive(false);
        down.SetActive(true);
        DialogMove.dialogcnt = 5;
        DialogMove.dialogup = true;
        FadeInOut.fadein = true;
    }
    IEnumerator WaitTime() //
    {
        DirectionButton.isLiving = true; 
        DirectionButton.isBed = false; 
        anim.SetTrigger("BlackDoorClick");
        yield return new WaitForSeconds(2f);
        fadeImg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        livingroom.SetActive(true);
        bedroom.SetActive(false);
        FadeInOut.fadein = true;
        anim.SetTrigger("BlackDoorIdle");
    }
}
