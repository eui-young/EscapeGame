using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;

public class DirectionButton : MonoBehaviour
{
    public GameObject[] bedside = new GameObject[4];
    public GameObject[] livingSide = new GameObject[4];

    public GameObject[] expand = new GameObject[7];
    public Image BlackBg;
    public GameObject down;

    public GameObject expandbg1;
    public GameObject expandbg2;
    public GameObject expandbg3;
    public GameObject expandbg4;
    public GameObject expandbg5;
    bool leftbt;
    bool rightbt;
    
    public GameObject livingroom;//
    public GameObject restroom;//
    public GameObject bedroom; //

    public GameObject expandBg;//
    public GameObject[] item; //

    public Image rightBtImg; //
    public Image leftBtImg;//
    public GameObject clockBg; //
    public GameObject numberBoxBg; //
    public GameObject patternBox; //
    public GameObject bedClockBg; //
    public GameObject Cardgame;
    public GameObject Lightgame;
    public GameObject theKey;

    public static bool isLiving; //
    public static bool isBed; //
    public static bool isRest; //
    private void Start() //
    {
        isLiving = true;
        isBed = false;
    }
    public void LeftButton()
    {
        leftbt = true;
        DialogMove.dialogdown = true; //
        DialogMove.dialogup = false; //
        StartCoroutine(waittime());  
    }
    public void RightButton()
    {
        rightbt = true;
        DialogMove.dialogdown = true; //
        DialogMove.dialogup = false; //
        StartCoroutine(waittime());
    }
    public void DownButton() 
    {
        if (theKey.activeSelf)
        {
            expandBg.SetActive(false);
            theKey.SetActive(false);
            down.SetActive(false);
        }
        if (isBed) //
        {
            if (Lightgame.activeSelf) //전구 게임 닫기
            {
                StartCoroutine(OutMotion(Lightgame, bedroom));
            }
            if (Cardgame.activeSelf) //카드 게임 닫기
            {
                StartCoroutine(OutMotion(Cardgame, bedroom));
            }
            if (expandbg1.activeSelf || expandbg2.activeSelf || expandbg3.activeSelf|| expandbg4.activeSelf || expandbg5.activeSelf) //아이템 확대창 연 게 있다면 닫기
            {
                for (int i = 0; i < expand.Length; i++)
                {
                    if (expand[i].activeSelf == true)
                        expand[i].SetActive(false);
                }
                down.gameObject.SetActive(false);
                expandbg1.SetActive(false);
                expandbg2.SetActive(false);
                expandbg3.SetActive(false);
                expandbg4.SetActive(false);
                expandbg5.SetActive(false);
            }
            else if(theKey.activeSelf==false)//그 외, 가구 확대한 게 있다면 닫기
            {
                if (bedside[0].activeSelf) //액자 확대했을 때 닫기
                    StartCoroutine(OutMotion(expand[0], bedroom));
                if (bedside[1].activeSelf) //거울 확대했을 때 닫기
                {
                    StartCoroutine(OutMotion(expand[3], bedroom)); 
                }
                if (bedside[3].activeSelf)
                {
                    if(patternBox.activeSelf)
                        StartCoroutine(OutMotion(patternBox, bedroom));
                    if(bedClockBg.activeSelf)
                        StartCoroutine(OutMotion(bedClockBg, bedroom));
                }
            }
            rightBtImg.gameObject.SetActive(true);
            leftBtImg.gameObject.SetActive(true);
        }
        if (isLiving) //
        {
            if (expandBg.activeSelf)
            {
                for(int i=0; i<item.Length; i++)
                    item[i].SetActive(false);
                expandBg.SetActive(false);
                down.gameObject.SetActive(false);
            }
            else
            {
                if (livingSide[0].activeSelf)
                    StartCoroutine(OutMotion(clockBg, livingroom));
                if (livingSide[3].activeSelf)
                    StartCoroutine(OutMotion(numberBoxBg, livingroom));
            }
        }
        if (isRest&&theKey.activeSelf==false) //
        {
            isRest = false;
            isLiving = true;
            StartCoroutine(OutMotion(restroom, livingroom));
        }
    }
    IEnumerator OutMotion(GameObject outObject, GameObject inObject) //
    {
        BlackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        inObject.SetActive(true);
        outObject.SetActive(false);
        FadeInOut.fadein = true;
        rightBtImg.gameObject.SetActive(true);
        leftBtImg.gameObject.SetActive(true);
        down.SetActive(false);
    }
    IEnumerator waittime()
    {
        GameObject[] side = new GameObject[4]; //
        if (isLiving) //
            side = livingSide;
        else if (isBed) //
            side = bedside;
        BlackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        if(leftbt==true)
        {
            leftbt = false;
            for (int i = 0; i < 4; i++)
            {
                if (side[3].activeSelf == true)
                {
                    side[3].SetActive(false);
                    side[0].SetActive(true);
                    break;
                }
                else if (side[i].activeSelf == true)
                {
                    side[i].SetActive(false);
                    side[i + 1].SetActive(true);
                    break;
                }
            }
        }
        else if(rightbt==true)
        {
            rightbt = false;
            for (int i = 0; i < 4; i++)
            {
                if (side[0].activeSelf == true)
                {
                    side[0].SetActive(false);
                    side[3].SetActive(true);
                    break;
                }
                else if (side[i].activeSelf == true)
                {
                    side[i].SetActive(false);
                    side[i - 1].SetActive(true);
                    break;
                }
            }
        }
        FadeInOut.fadein = true;
    }
}
