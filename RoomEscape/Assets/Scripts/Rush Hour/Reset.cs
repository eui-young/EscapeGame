using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public Image[] cars;
    public void ResetBtClick()
    {
        cars[0].transform.localPosition = new Vector2(-260, 320);
        cars[1].transform.localPosition = new Vector2(-260, 190);
        cars[2].transform.localPosition = new Vector2(-64, 260);
        cars[3].transform.localPosition = new Vector2(-320, -65);
        cars[4].transform.localPosition = new Vector2(-65, -65);
        cars[5].transform.localPosition = new Vector2(-190, -260);
        cars[6].transform.localPosition = new Vector2(260, 320);
        cars[7].transform.localPosition = new Vector2(320, 65);
        cars[8].transform.localPosition = new Vector2(190, 0);
        cars[9].transform.localPosition = new Vector2(260, -190);
        cars[10].transform.localPosition = new Vector2(260, -320);
        cars[11].transform.localPosition = new Vector2(65, -260);
        cars[12].transform.localPosition = new Vector2(-130,60);
    }
}
