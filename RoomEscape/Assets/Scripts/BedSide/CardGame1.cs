using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGame1 : MonoBehaviour
{
    public Image[] CardImage = new Image[10];
    public Sprite[] CardSprite = new Sprite[6];
    int[] Answer = { 1, 5, 4, 3, 2, 4, 2, 5, 1, 3 };
    int[] current = new int[10];

    float CurrentTime = 21f;
    int num = 0;//이전 카드 숫자
    bool firstTime;
    public Text tx;
    public Text timer;
    bool clear;
    public Image down;
    public GameObject left;
    public GameObject right;
    public GameObject expandbg;
    public GameObject key;
    public static bool getKey2=false; //열쇠조각2 얻었는지 확인

    public GameObject cardbt;

    public AudioSource thisAS;
    public AudioSource soundAS;
    public AudioClip cardOpen;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (!getKey2)
        {
            thisAS.Play();
            tx.gameObject.SetActive(false);
            CurrentTime = 21f;
            clear = false;
            firstTime = true;
            for (int i = 0; i < 10; i++)
            {
                current[i] = 0;
                //CardImage[i].sprite = CardSprite[Answer[i]];
            }
        }
        down.gameObject.SetActive(true);
        right.SetActive(false);
        left.SetActive(false);
    }
    private void Update()
    {
        if (CurrentTime > 0 && clear==false)
        {
            CurrentTime -= Time.deltaTime;
            timer.text = (int)CurrentTime + "초";
        }
        else if (CurrentTime <= 0)
        {
            thisAS.Stop();
            tx.text = "Fail !";
            tx.gameObject.SetActive(true);
        }
    }
    public void button1()
    {
        StartCoroutine(CardManager(0, 1));
    }
    public void button2()
    {
        StartCoroutine(CardManager(1, 5));
    }
    public void button3()
    {
        StartCoroutine(CardManager(2, 4));
    }
    public void button4()
    {
        StartCoroutine(CardManager(3, 3));
    }
    public void button5()
    {
        StartCoroutine(CardManager(4, 2));
    }
    public void button6()
    {
        StartCoroutine(CardManager(5, 4));
    }
    public void button7()
    {
        StartCoroutine(CardManager(6, 2));
    }
    public void button8()
    {
        StartCoroutine(CardManager(7, 5));
    }
    public void button9()
    {
        StartCoroutine(CardManager(8, 1));
    }
    public void button10()
    {
        StartCoroutine(CardManager(9, 3));
    }
    IEnumerator CardManager(int Cardinx, int CardNum)
    {
        soundAS.clip = cardOpen;
        soundAS.Play();
        if (current[Cardinx] != 0) //cardsprite change, state change
        {
            current[Cardinx] = 0;
            CardImage[Cardinx].sprite = CardSprite[0];
        }
        else
        {
            current[Cardinx] = CardNum;
            CardImage[Cardinx].sprite = CardSprite[CardNum];
            yield return new WaitForSeconds(0.5f);
        }

        if (firstTime == true) //card check
        {
            firstTime = false;
            num = CardNum;
        }
        else
        {
            firstTime = true; //다음 한쌍 받을 준비
            if (current[Cardinx] != num)
            {
                for (int i = 0; i < 10; i++)
                {
                    CardImage[i].sprite = CardSprite[0];
                    current[i] = 0;
                }
            }
        }
        for (int i = 0; i < 10; i++)
        {
            if (current[i] == 0)
            {
                clear = false;
                break;
            }
            else
            {
                if (i == 9 && current[i] != 0)
                {
                    clear = true;
                }
            }
        }
        if (clear == true)
        {
            thisAS.Stop();
            tx.text = "Clear!";
            tx.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            this.gameObject.SetActive(false);
            expandbg.SetActive(true);
            key.SetActive(true);
            DialogMove.dialogcnt = 19;
            DialogMove.dialogup= true;
            getKey2 = true;
            cardbt.SetActive(false);
        }
    }
}
