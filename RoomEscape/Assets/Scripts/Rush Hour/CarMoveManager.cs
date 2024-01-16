using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarMoveManager : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Image blindImg;
    public bool horizon; //가로인지
    public bool isKey; //빨간차인지
    public bool isBus; //버스인지
    private bool isControl; //칸 이동
    private bool isCrush; //충돌
    private bool thisMove; //마우스를 올린 오브젝트
    private bool isMouseDown; //드래그 중인지
    private Vector2 mousePostion;

    private float fX, fY, sX, sY;
    float tempX, tempY, squareX, squareY, square;

    public AudioSource soundAS;
    public AudioClip carHorn;
    public AudioClip carCrush;

    void Awake()
    {
        fX = transform.localPosition.x;
        fY = transform.localPosition.y;
    }
    void Update()
    {
        if (isControl) //칸 이동
        {
            if (horizon) //가로 차
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition,
                    new Vector2(fX - square, transform.localPosition.y),20f);
                if (transform.localPosition.x == fX-square)
                {
                    fX = transform.localPosition.x;
                    isControl = false; thisMove = false;
                }
            }
            else //세로 차
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition,
                    new Vector2(transform.localPosition.x, fY - square), 20f);
                if (transform.localPosition.y == fY - square)
                {
                    fY = transform.localPosition.y;
                    isControl = false; thisMove = false;
                }
            }
        }
        if (isCrush) //벽 충돌했을 때 칸 이동
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition,
                new Vector2(fX, fY), 20f);
            if (transform.localPosition.x == fX && transform.localPosition.y == fY)
            {
                isCrush = false;
            }
        }
        if (isKey&&transform.localPosition.x==390) //게임 클리어
        {
            blindImg.gameObject.SetActive(true);
            GameClear.isRHClear = true;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isMouseDown = true;
        thisMove = true;
        soundAS.clip = carHorn;
        soundAS.Play();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isControl&&!isCrush&&isMouseDown)
        {
            if (horizon)
            {
                mousePostion = new Vector2(Input.mousePosition.x, transform.position.y);
            }
            else
            {
                mousePostion = new Vector2(transform.position.x, Input.mousePosition.y);
            }
            transform.position = mousePostion;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isCrush&&!isControl) //부딪치지 않았을 때
        {
            sX = transform.localPosition.x;
            sY = transform.localPosition.y;
            tempX = fX - sX;
            tempY = fY - sY;
            squareX = tempX / 130;
            squareY = tempY / 130;
            if (horizon)
                square = 130 * Mathf.Round(squareX);
            else
                square = 130 * Mathf.Round(squareY);
            isControl = true;
        }
        isMouseDown = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isMouseDown = false;
        int temp=0;
        if (isBus)
            temp = 65;
        if (collision.gameObject.tag == "Car"&&thisMove)
        {
            sX = transform.localPosition.x;
            sY = transform.localPosition.y;
            tempX = fX - sX;
            tempY = fY - sY;
            squareX = tempX / 130;
            squareY = tempY / 130;
            if (horizon)
                square = 130 * (int)squareX;
            else
                square = 130 * (int)squareY;
            isControl = true;
        }
        if (collision.gameObject.tag == "leftWall")
        {
            fX = -260 + temp; isCrush = true;
        }
        if (collision.gameObject.tag == "rightWall")
        {
            fX = 260 - temp; isCrush = true;
        }
        if (collision.gameObject.tag == "topWall")
        {
            fY = 260 - temp; isCrush = true;
        }
        if (collision.gameObject.tag == "bottomWall")
        {
            fY = -260 + temp; isCrush = true;
        }

        soundAS.clip = carCrush;
        soundAS.Play();
    }
}
