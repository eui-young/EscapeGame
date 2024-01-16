using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberUpDown : MonoBehaviour
{
    public bool[] squares;
    public Text mainTx;
    public Text sideTx;
    private int number;
    private Vector2 bottomPostion = new Vector2(-235, -325);
    private Vector2 centerPostion = new Vector2(-235, -185);
    private Vector2 topPostion = new Vector2(-235, -45);

    private bool isUp, isDown,isClear;

    public AudioSource soundAS;
    public AudioClip buttonClick;
    private void Update()
    {
        if (isUp)
            MoveNumber(topPostion, centerPostion);
        if (isDown)
            MoveNumber(bottomPostion, centerPostion);
    }
    public void UpBtClick()
    {
        if (!isUp && !isDown&&!isClear)
        {
            number++;
            if (mainTx.text == "9") number = 0;
            sideTx.text = number.ToString();
            sideTx.transform.localPosition = bottomPostion;
            isUp = true;
        }
        soundAS.clip = buttonClick;
        soundAS.Play();
    }
    public void DownBtClick()
    {
        if (!isUp && !isDown&&!isClear)
        {
            number--;
            if (mainTx.text == "0") number = 9;
            sideTx.text = number.ToString();
            sideTx.transform.localPosition = topPostion;
            isDown = true;
        }
        soundAS.clip = buttonClick;
        soundAS.Play();
    }
    private void MoveNumber(Vector2 mainTxPostion, Vector2 sideTxPostion)
    {
        mainTx.transform.localPosition = Vector2.MoveTowards(mainTx.transform.localPosition, mainTxPostion, 7f);
        sideTx.transform.localPosition = Vector2.MoveTowards(sideTx.transform.localPosition, sideTxPostion, 7f);
        if (mainTx.transform.localPosition.y == mainTxPostion.y)
        {
            Text tempTx;
            tempTx = sideTx;
            sideTx = mainTx;
            mainTx = tempTx;
            CheckClear();
            isUp = false; isDown = false;
        }
    }
    private void CheckClear()
    {
        if (squares[0] && mainTx.text == "9")
            NumberBoxClear.isNumberBoxClear[0] = true;
        else if (squares[0] && mainTx.text != "9")
            NumberBoxClear.isNumberBoxClear[0] = false;
        if (squares[1] && mainTx.text == "7")
            NumberBoxClear.isNumberBoxClear[1] = true;
        else if (squares[1] && mainTx.text != "7")
            NumberBoxClear.isNumberBoxClear[1] = false;
        if (squares[2] && mainTx.text == "3")
            NumberBoxClear.isNumberBoxClear[2] = true;
        else if (squares[2] && mainTx.text != "3")
            NumberBoxClear.isNumberBoxClear[2] = false;
        if (squares[3] && mainTx.text == "8")
            NumberBoxClear.isNumberBoxClear[3] = true;
        else if (squares[3] && mainTx.text != "8")
            NumberBoxClear.isNumberBoxClear[3] = false;
        if (NumberBoxClear.isNumberBoxClear[0] && NumberBoxClear.isNumberBoxClear[1] && NumberBoxClear.isNumberBoxClear[2] && NumberBoxClear.isNumberBoxClear[3])
            isClear = true;
        else
            isClear = false;
        Debug.Log(NumberBoxClear.isNumberBoxClear[0] + ", " + NumberBoxClear.isNumberBoxClear[1] + ", " + NumberBoxClear.isNumberBoxClear[2] + ", " + NumberBoxClear.isNumberBoxClear[3]);
    }
}
