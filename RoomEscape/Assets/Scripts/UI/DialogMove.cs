using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogMove : MonoBehaviour
{
    public Image Dialog;
    public Text dialogtx;

    public static bool dialogup;
    public static bool dialogdown;
    public static int dialogcnt;

    string[] dialogtext ={
        "선반 안에 종이가 있어.",  //0 
        "벽 안에 무언가가 있는 거 같아.", //1
        "옷장 열쇠", //2
        "침대에는 아무것도 없어.", //3
        "단단히 잠겨 있어. 열쇠가 필요해.", //4
        "액자 안에 무언가가 그려져 있어.", //5
        "거울에 뭔가가 비치는거 같은데.", //6
        "어릴 때 가지고 놀았던 토끼 인형이잖아?", //7
        "옷장을 열려면 열쇠가 필요해.", //8
        "옷장 안에 종이가 있어.", //9
        "책상 위에는 아무것도 없어.", //10
        "잠겨 있어. 현관문 같은데...열쇠가 필요해.", //11
        "열쇠의 일부분", //12 열쇠조각3
        "숫자와 문양이 그려져 있어.", //13 거실B 쪽지
        "책상 열쇠", //14 거실D 책상열쇠
        "문이 잠겨 있어. 열쇠가 필요해.", //15 거실D 화장실문
        "1과...사각형인가?", //16 거실D 소파
        "열쇠의 일부분과 접착제", //17 방D 상자로
        "화장실 열쇠", //18 방D 시계로
        "열쇠의 일부분", //19 열쇠조각 2
        "이제 여기선 찾아볼게 없는거 같아.", //20 열쇠 조각 얻고나서 책상 클릭시
        "서랍을 열기 위해 열쇠가 필요해", //21
        "서랍안에 카드더미가 있어.", //22
        "선반 열쇠", //23
        "잠겨 있군.", //24
        "현관 열쇠!", //25
        "뭔가가 바뀐 것 같은데? 다른 커튼인가?", //26
        "97이라고 적혀 있다.", //27
        "불을 그린 건가?" //28
    };

    // Update is called once per frame
    void Update()
    {
        dialogtx.text = dialogtext[dialogcnt];
        if (dialogup == true)
        {
            Vector3 pos = new Vector3(Dialog.transform.position.x, -4.7f, 0f);
            Dialog.transform.position = Vector3.MoveTowards(Dialog.transform.position, pos, 0.1f);
            dialogdown = false;
        }
        else if (dialogdown == true)
        {
            Vector3 pos = new Vector3(Dialog.transform.position.x, -5.7f, 0f);
            Dialog.transform.position = Vector3.MoveTowards(Dialog.transform.position, pos, 0.1f);
        }
    }
    public void DialogClick() //대화창 클릭시
    {
        dialogdown = true;
        dialogup = false;
    }
}
