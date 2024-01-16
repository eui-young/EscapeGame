using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image inventbg;
    public Image[] item = new Image[6];
    public Image[] blind = new Image[6];
    string[] itemname = new string[6];
    public Sprite[] itemimage;

    public Image expandBg;
    public Image theKey;
    public GameObject downBt;

    bool click;
    float x = 8.25f;
    float x2 = 9.75f;

    public static bool opencloset;
    public static bool opendesk;
    public static bool openshelf;
    public static bool openRestroom;
    public static bool openTheDoor;

    private bool useKey1;
    private bool useKey2;
    private bool useKey3;
    private bool useBond;

    private bool isOne=true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<itemname.Length; i++)
        {
            itemname[i] = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        itemupdate();
        if (click==true)
        {
            Vector3 pos = new Vector3(x, inventbg.transform.position.y, 0);
            inventbg.transform.position = Vector3.MoveTowards(inventbg.transform.position, pos, 0.1f);
        }
        else
        {
            Vector3 pos = new Vector3(x2, inventbg.transform.position.y, 0);
            inventbg.transform.position = Vector3.MoveTowards(inventbg.transform.position, pos, 0.1f);
        }

        if(SideAManager.getclosetkey==true &&SideCManager.useclosetkey==false) //옷장열쇠
        {
            string str = "getclosetkey";
            ItemMarge(str,0);
        }
        if (GameClear.getKey3 && useKey3==false) //열쇠 조각3
        {
            string str = "getKey3";
            ItemMarge(str, 1);
        } 
        if (NumberBoxClear.getDeskKey && SideCManager.usedeskkey == false)//책상 열쇠
        {
            string str = "getDeskKey";
            ItemMarge(str, 2);
        }
        if (PatternBoxClear.getBond && useBond == false) //접착제
        {
            string str = "getBond";
            ItemMarge(str, 3);
        }
        if (PatternBoxClear.getKey1 && useKey1 == false) //열쇠 조각1
        {
            string str = "getKey1";
            ItemMarge(str, 4);
        }
        if (BedClockClear.getRestroomKey && LivingSideDManager.useRestroomKey == false) //화장실 열쇠
        {
            string str = "getRestroomKey";
            ItemMarge(str, 5);
        }
        if(CardGame1.getKey2 && useKey2 == false) //열쇠 조각2
        {
            string str = "getKey2";
            ItemMarge(str, 6);
        }
        if (LigntGame.getshelfkey && SideAManager.useshelfkey == false) //선반열쇠
        {
            string str = "getshelfkey";
            ItemMarge(str, 7);
        }
        if (useBond && useKey1 && useKey2 && useKey3) //현관열쇠
        {
            string str = "getTheKey";
            ItemMarge(str, 8);
        }
    }
    public void inventClick()
    {
        if (click == true)
            click = false;
        else
            click = true;
    }
    void ItemMarge(string str,int cnt)
    {
        bool isHas=false;
        for (int i = 0; i < 6; i++)
        {
            if (itemname[i].Equals(str))
                isHas = true;
        }
        for(int i=0; i<6; i++)
        {
            if (itemname[i].Equals("")&& isHas == false)
            {
                itemname[i] = str;
                item[i].sprite = itemimage[cnt];
                item[i].gameObject.SetActive(true);
                break;
            }
        }
    }
    void itemupdate() // 아이템 소비했을때 위에서부터 다시 정렬
    {
        for(int i=0; i<itemname.Length; i++)
        {
            if (SideCManager.useclosetkey == true && itemname[i] == "getclosetkey")
            {
                itemname[i] = "";
                item[i].gameObject.SetActive(false);
                blind[i].gameObject.SetActive(false);
            }
            else if (SideCManager.usedeskkey == true && itemname[i] == "getDeskKey")
            {
                itemname[i] = "";
                item[i].gameObject.SetActive(false);
                blind[i].gameObject.SetActive(false);
            }
            else if (SideAManager.useshelfkey == true && itemname[i] == "getshelfkey")
            {
                itemname[i] = "";
                item[i].gameObject.SetActive(false);
                blind[i].gameObject.SetActive(false);
            }
            else if (LivingSideDManager.useRestroomKey && itemname[i] == "getRestroomKey")
            {
                itemname[i] = "";
                item[i].gameObject.SetActive(false);
                blind[i].gameObject.SetActive(false);
            }
            else if (useKey1&&useKey2&&useKey3&&useBond && itemname[i] == "getBond")
            {
                itemname[i] = "";
                item[i].gameObject.SetActive(false);
                blind[i].gameObject.SetActive(false);
            }
            else if (useKey1 && useKey2 && useKey3 && useBond && itemname[i] == "getKey1")
            {
                itemname[i] = "";
                item[i].gameObject.SetActive(false);
                blind[i].gameObject.SetActive(false);
            }
            else if (useKey1 && useKey2 && useKey3 && useBond && itemname[i] == "getKey2")
            {
                itemname[i] = "";
                item[i].gameObject.SetActive(false);
                blind[i].gameObject.SetActive(false);
            }
            else if (useKey1 && useKey2 && useKey3 && useBond && itemname[i] == "getKey3")
            {
                itemname[i] = "";
                item[i].gameObject.SetActive(false);
                blind[i].gameObject.SetActive(false);
            }
        }
    }
    public void item1click()
    {
        itemUse(0);
    }
    public void item2click()
    {
        itemUse(1);
    }
    public void item3Click()
    {
        itemUse(2);
    }
    public void item4Click()
    {
        itemUse(3);
    }
    public void item5Click()
    {
        itemUse(4);
    }
    public void item6Click()
    {
        itemUse(5);
    }
    void itemUse(int cnt)
    {
        if (itemname[cnt].Equals("getclosetkey"))
        {
            if (opencloset == false)
                opencloset = true;
            else
                opencloset = false;
        }
        if(itemname[cnt].Equals("getDeskKey"))
        {
            if (opendesk == false)
                opendesk = true;
            else
                opendesk = false;
        }
        if (itemname[cnt].Equals("getshelfkey"))
        {
            if (openshelf == false)
                openshelf = true;
            else
                openshelf = false;
        }
        if (itemname[cnt].Equals("getRestroomKey"))
        {
            if (openRestroom == false)
                openRestroom = true;
            else
                openRestroom = false;
        }
        if (itemname[cnt].Equals("getKey1"))
        {
            if (useKey1 == false)
                useKey1 = true;
            else
                useKey1 = false;
        }
        if (itemname[cnt].Equals("getKey2"))
        {
            if (useKey2 == false)
                useKey2 = true;
            else
                useKey2 = false;
        }
        if (itemname[cnt].Equals("getKey3"))
        {
            if (useKey3 == false)
                useKey3 = true;
            else
                useKey3 = false;
        }
        if (itemname[cnt].Equals("getBond"))
        {
            if (useBond == false)
                useBond = true;
            else
                useBond = false;
        }
        if (itemname[cnt].Equals("getTheKey"))
        {
            if (openTheDoor == false)
                openTheDoor = true;
            else
                openTheDoor = false;
        }

        if (blind[cnt].gameObject.activeSelf)
            blind[cnt].gameObject.SetActive(false);
        else if(itemname[cnt]!="")
            blind[cnt].gameObject.SetActive(true);

        if (useKey1 && useKey2 && useKey3 && useBond&&isOne)
        {
            isOne = false;
            expandBg.gameObject.SetActive(true);
            theKey.gameObject.SetActive(true);
            DialogMove.dialogup = true;
            DialogMove.dialogcnt = 25;
            downBt.SetActive(true);
        }

    }
}
