using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PatternUpDown : MonoBehaviour
{
    public bool[] squares;
    public Sprite[] patternSprite; //0: Ractangle 1: Triangle 2: Circle 3: Hearts
    public Image mainImg;
    public Image sideImg;
    private Vector2 bottomPostion = new Vector2(-237, -330);
    private Vector2 centerPostion = new Vector2(-237, -190);
    private Vector2 topPostion = new Vector2(-237, -50);

    private int patternIndex;
    private bool isUp, isDown, isClear;

    public AudioSource soundAS;
    public AudioClip buttonClick;
    private void Awake()
    {
        patternIndex = 1;
        mainImg.sprite = patternSprite[1];
    }
    private void Start()
    {
        PatternBoxClear.isPatternBoxClear[3] = true;
    }
    private void Update()
    {
        if (isUp)
            MovePattern(topPostion, centerPostion);
        if (isDown)
            MovePattern(bottomPostion, centerPostion);
    }
    public void UpBtClick()
    {
        if (!isUp && !isDown&& !isClear)
        {
            patternIndex++;
            sideImg.transform.localPosition = bottomPostion;
            if (patternIndex > 3) patternIndex = 0;
            isUp = true;
        }
        soundAS.clip = buttonClick;
        soundAS.Play();
    }
    public void DownBtClick()
    {
        if (!isUp && !isDown&& !isClear)
        {
            patternIndex--;
            sideImg.transform.localPosition = topPostion;
            if (patternIndex < 0) patternIndex = 3;
            isDown = true;
        }
        soundAS.clip = buttonClick;
        soundAS.Play();
    }
    private void MovePattern(Vector2 mainImgPostion,Vector2 sideImgPostion)
    {
        sideImg.sprite = patternSprite[patternIndex];
        mainImg.transform.localPosition = Vector2.MoveTowards(mainImg.transform.localPosition, mainImgPostion, 7f);
        sideImg.transform.localPosition = Vector2.MoveTowards(sideImg.transform.localPosition, sideImgPostion, 7f);
        if (mainImg.transform.localPosition.y == mainImgPostion.y)
        {
            Image tempImg;
            tempImg=sideImg;
            sideImg = mainImg;
            mainImg = tempImg;
            CheckClear();
            isUp = false; isDown = false;
        }
    }
    private void CheckClear()
    {
        if (squares[0] && mainImg.sprite == patternSprite[0])
            PatternBoxClear.isPatternBoxClear[0] = true;
        else if(squares[0] && mainImg.sprite != patternSprite[0])
            PatternBoxClear.isPatternBoxClear[0] = false;
        if (squares[1]&& mainImg.sprite == patternSprite[3])
            PatternBoxClear.isPatternBoxClear[1] = true;
        else if(squares[1] && mainImg.sprite != patternSprite[3])
            PatternBoxClear.isPatternBoxClear[1] = false;
        if (squares[2]&& mainImg.sprite == patternSprite[2])
            PatternBoxClear.isPatternBoxClear[2] = true;
        else if (squares[2] && mainImg.sprite != patternSprite[2])
            PatternBoxClear.isPatternBoxClear[2] = false;
        if (squares[3]&& mainImg.sprite== patternSprite[1])
            PatternBoxClear.isPatternBoxClear[3] = true;
        else if(squares[3] && mainImg.sprite != patternSprite[1])
            PatternBoxClear.isPatternBoxClear[3] = false;
        if (PatternBoxClear.isPatternBoxClear[0] && PatternBoxClear.isPatternBoxClear[1] && PatternBoxClear.isPatternBoxClear[2] && PatternBoxClear.isPatternBoxClear[3])
            isClear = true;
        else
            isClear = false;
        Debug.Log(PatternBoxClear.isPatternBoxClear[0] + ", " + PatternBoxClear.isPatternBoxClear[1]+ ", " + PatternBoxClear.isPatternBoxClear[2] + ", " + PatternBoxClear.isPatternBoxClear[3]);
    }
}