using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;
public class RestroomManager : MonoBehaviour
{
    public GameObject rightBt;
    public GameObject leftBt;
    public GameObject downBt;

    public GameObject livingroom;
    public GameObject restroom;

    public Image mirror;
    public Image washstand;
    public Image washstand_Water;
    public Sprite washstandSp;

    private bool isCheck=false;
    private bool isMirrorOn;

    private void Update()
    {
        if (!isCheck && isMirrorOn)
            StartCoroutine(mirrorEffect());
    }
    public void handleClick()
    {
        if (washstand_Water.gameObject.activeSelf)
            washstand_Water.gameObject.SetActive(false);
        else
        {
            washstand_Water.gameObject.SetActive(true);
            isMirrorOn = true;
        }
    }
    private void OnEnable()
    {
        rightBt.SetActive(false);
        leftBt.SetActive(false);
        downBt.SetActive(true);
    }
    IEnumerator mirrorEffect()
    {
        Color tempColor = mirror.color;
        tempColor.a = 0f;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / 1f;
            mirror.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
            }
            yield return null;
        }
        isMirrorOn = false;
        isCheck = true;
    }
}
