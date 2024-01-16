using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
public class SideDManager : MonoBehaviour
{
    public GameObject down;
    public Image[] shape = new Image[8];
    public Sprite[] shapeimage = new Sprite[4];
    public GameObject expandbg;
    public Image expandtable;

    public GameObject clockBg;
    public GameObject patterBox;
    public Image blackBg;
    public GameObject rightBt;
    public GameObject leftBt;
    public GameObject downBt;

    int[] cnt = new int[4];
    int[] shapecnt = new int[4];

    Vector3 pos3;

    bool []move=new bool[8];
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void clockClick()
    {
        StartCoroutine(ObjectCloser(clockBg));
    }
    public void patterBoxClick()
    {
        StartCoroutine(ObjectCloser(patterBox));
    }
    IEnumerator ObjectCloser(GameObject onObject)
    {
        blackBg.gameObject.SetActive(true);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        onObject.gameObject.SetActive(true);
        rightBt.SetActive(false);
        leftBt.SetActive(false);
        downBt.SetActive(true);
        FadeInOut.fadein = true;
    }
    public void bedClick()
    {
        DialogMove.dialogcnt = 3;
        DialogMove.dialogup = true;
    }
    public void tableClick()
    {
        expandbg.SetActive(true);
        expandtable.gameObject.SetActive(true);
        down.SetActive(true);
    }
    void directionmoveup(int a)
    {
        if (cnt[a] == 3)
        {
            cnt[a] = 0;
        }
        else
        {
            cnt[a] += 1;
        }
        if(shapecnt[a/2]==0)
        {      
            shape[a + 1].gameObject.SetActive(false);
            shape[a + 1].transform.position = pos3;
            shape[a + 1].sprite = shapeimage[cnt[a]];
        }
        else
        {
            shape[a - 1].gameObject.SetActive(false);
            shape[a - 1].transform.position = pos3;
            shape[a - 1].sprite = shapeimage[cnt[a]];
        }
        move[a] = true;
    }
    public void up1bt()
    {
        directionmoveup(0);
    }
}
