using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingSideCManager : MonoBehaviour
{
    public Image curtain;
    public Image blindB;
    public Image blindD;
    public Sprite curtainOpenSp;
    public Sprite curtainCloseSp;

    public AudioSource soundAS;
    public AudioClip curtainClip;
    public void curtainClick()
    {
        if (curtain.sprite == curtainOpenSp)
            curtain.sprite = curtainCloseSp;
        else
        {
            DialogMove.dialogup = true;
            DialogMove.dialogcnt = 26;
            curtain.sprite = curtainOpenSp;
            blindB.gameObject.SetActive(false);
            blindD.gameObject.SetActive(false);
        }

        soundAS.clip = curtainClip;
        soundAS.Play();
    }
}
