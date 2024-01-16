using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LigntGame : MonoBehaviour
{
    public Image[] lights = new Image[9];
    public Sprite on;
    public Sprite off;

    public bool[] islighting1 = { false, false,true, false, true, false, true, false, false };
    public bool[] islighting2 = { true,false,false, false, true, true, true, false, false };
    public bool[] islighting3 = { false, true, true, true, false, false, true, false, true };

    public bool[] click = new bool[9];
    public GameObject noclick;

    public int cnt;
    public bool isplaying;
    public GameObject cleartx;
    public GameObject expand;
    public GameObject key;
    public static bool getshelfkey;
    public bool isclear;
    public int a;

    public Image blackBg;
    public AudioSource soundAS;
    public AudioClip lightOn;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (!getshelfkey)
        {
            a = 0;
            for (int i = 0; i < 9; i++)
            {
                click[i] = false;
                lights[i].sprite = off;
            }
            StartCoroutine(lighting1());
        }
    }

    // Update is called once per frame
    IEnumerator lighting1()
    {
        isclear = false;
        yield return new WaitForSeconds(2.5f);
        for (int i=0; i<9; i++)
        {
            click[i] = false;
            lights[i].sprite = off;
        }
        noclick.SetActive(true);
        cnt = 1;
        isplaying = true;
        for(int i=0; i < 9; i++) //순서대로 불켜주기
        {
            if (islighting1[i] == true)
            {
                soundAS.clip = lightOn;
                soundAS.Play();

                lights[i].sprite = on;
                yield return new WaitForSeconds(0.5f);

                lights[i].sprite = off;
            }
        }
        noclick.SetActive(false);
        isplaying = false;
    }
    IEnumerator lighting2()
    {
        isclear = false;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 9; i++)
        {
            click[i] = false;
            lights[i].sprite = off;
        }
        noclick.SetActive(true);
        cnt = 2;
        isplaying = true;
        for (int i = 0; i < 9; i++) //순서대로 불켜주기
        {
            if (islighting2[i] == true)
            {
                soundAS.clip = lightOn;
                soundAS.Play();

                lights[i].sprite = on;

                yield return new WaitForSeconds(0.5f);

                lights[i].sprite = off;
            }
        }
        noclick.SetActive(false);
        isplaying = false;
    }
    IEnumerator lighting3()
    {
        isclear = false;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 9; i++)
        {
            click[i] = false;
            lights[i].sprite = off;
        }
        noclick.SetActive(true);
        cnt = 3;
        isplaying = true;
        for (int i = 0; i < 9; i++) //순서대로 불켜주기
        {
            if (islighting3[i] == true)
            {
                soundAS.clip = lightOn;
                soundAS.Play();

                lights[i].sprite = on;

                yield return new WaitForSeconds(0.5f);

                lights[i].sprite = off;
            }
        }
        noclick.SetActive(false);
        isplaying = false;
    }
    public void lightclick1()
    {
        onoff(0);
    }
    public void lightclick2()
    {
        onoff(1);
    }
    public void lightclick3()
    {
        onoff(2);
    }
    public void lightclick4()
    {
        onoff(3);
    }
    public void lightclick5()
    {
        onoff(4);
    }
    public void lightclick6()
    {
        onoff(5);
    }
    public void lightclick7()
    {
        onoff(6);
    }
    public void lightclick8()
    {
        onoff(7);
    }
    public void lightclick9()
    {
        onoff(8);
    }

    public void onoff(int a)
    {
        soundAS.clip = lightOn;
        soundAS.Play();

        lights[a].sprite = on;
        click[a] = true;
        if(cnt==1)
        {
            if (click[a] != islighting1[a])
            {
                StartCoroutine(lighting1());
            }
            else
            {
                iscollect();
            }
        }
        else if(cnt==2)
        {
            if (click[a] != islighting2[a])
            {
                StartCoroutine(lighting1());
            }
            else
            {
                iscollect();
            }
        }
        else
        {
            if (click[a] != islighting3[a])
            {
                StartCoroutine(lighting1());
            }
            else
            {
                iscollect();
            }
        }

    }
    public void iscollect()
    {
        if (cnt == 1)
        {
            for (int i = 0; i < 9; i++)
            {
                if (click[i] != islighting1[i])
                {
                    return;
                }
            }
            StartCoroutine(lighting2());
        }
        else if (cnt == 2)
        {
            for (int i = 0; i < 9; i++)
            {
                if (click[i] != islighting2[i])
                {
                    return;
                }
            }
            StartCoroutine(lighting3());
        }
        else if (cnt == 3)
        {
            for (int i = 0; i < 9; i++)
            {
                if (click[i] != islighting3[i])
                {
                    return;
                }
            }
            StartCoroutine(clear());
        }
    }

    IEnumerator clear()
    {
        blackBg.gameObject.SetActive(true);
        cleartx.SetActive(true);
        yield return new WaitForSeconds(1f);
        FadeInOut.fadeout = true;
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        getshelfkey = true;
        expand.SetActive(true);
        key.SetActive(true);
        DialogMove.dialogcnt = 23;
        DialogMove.dialogup = true;
        FadeInOut.fadein = true;
    }
}
