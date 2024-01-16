using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{
    public Image bgm;
    public Image sound;
    public Sprite speakerOn;
    public Sprite speakerOff;

    public AudioSource bgmAS;
    public AudioSource soundAS;
    public AudioSource clockAS;
    public AudioSource bedClockAS;
    public AudioSource cardGameAS;
    public AudioSource waterAS;
    public void BgmClick()
    {
        if(bgm.sprite==speakerOff)
        {
            bgmAS.mute = false;
            bgm.sprite = speakerOn;
        }
        else
        {
            bgmAS.mute = true;
            bgm.sprite = speakerOff;
        }
    }
    public void SoundClick()
    {
        if (sound.sprite == speakerOff)
        {
            soundAS.mute = false;
            cardGameAS.mute = false;
            clockAS.mute = false;
            bedClockAS.mute = false;
            waterAS.mute = false;
            sound.sprite = speakerOn;
        }
        else
        {
            soundAS.mute = true;
            cardGameAS.mute = true;
            clockAS.mute = true;
            bedClockAS.mute = true;
            waterAS.mute = true;
            sound.sprite = speakerOff;
        }
    }
}
