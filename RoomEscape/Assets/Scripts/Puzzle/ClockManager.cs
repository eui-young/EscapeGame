using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour, IDragHandler,IEndDragHandler
{
    public float clockSpeed = 1.5f;
    public bool hour;
    public bool minute;
    public int clearAngle;

    Vector2 fPostion = new Vector2(0, 0);
    public void OnDrag(PointerEventData eventData)
    {
        if (transform.eulerAngles.z < 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        if (transform.eulerAngles.z == 0 || transform.eulerAngles.z == 360)
        {
            if (fPostion.x > Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + clockSpeed);
            else
                transform.eulerAngles = new Vector3(0, 0, 359);
        }
        else if (transform.eulerAngles.z > 0&&transform.eulerAngles.z<=90)
        {
            if (fPostion.y > Input.mousePosition.y || fPostion.x > Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + clockSpeed);
            else if (fPostion.y < Input.mousePosition.y || fPostion.x < Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - clockSpeed);
        }
        else if (transform.eulerAngles.z > 90 && transform.eulerAngles.z <= 180)
        {
            if (fPostion.y > Input.mousePosition.y || fPostion.x < Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + clockSpeed);
            else if (fPostion.y < Input.mousePosition.y || fPostion.x > Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - clockSpeed);
        }
        else if (transform.eulerAngles.z > 180 && transform.eulerAngles.z <= 270)
        {
            if (fPostion.y < Input.mousePosition.y || fPostion.x < Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + clockSpeed);
            else if (fPostion.y > Input.mousePosition.y || fPostion.x > Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - clockSpeed);
        }
        else if (transform.eulerAngles.z > 270 && transform.eulerAngles.z < 360)
        {
            if (fPostion.y < Input.mousePosition.y || fPostion.x > Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + clockSpeed);
            else if (fPostion.y > Input.mousePosition.y || fPostion.x < Input.mousePosition.x)
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - clockSpeed);
        }
        fPostion = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.eulerAngles.z > clearAngle - 5 && transform.eulerAngles.z < clearAngle + 5)
        {
            if (DirectionButton.isBed)
            {
                if (hour)
                    BedClockClear.isBedHour = true;
                else if (minute)
                    BedClockClear.isBedMinute = true;
            }
            else
            {
                if (hour)
                    ClockClear.isHour = true;
                else if (minute)
                    ClockClear.isMinute = true;
            }
        }
        else
        {
            if (DirectionButton.isBed)
            {
                if (hour)
                    BedClockClear.isBedHour = false;
                else if (minute)
                    BedClockClear.isBedMinute = false;
            }
            else
            {
                if (hour)
                    ClockClear.isHour = false;
                else if (minute)
                    ClockClear.isMinute = false;
            }
        }
    }
}
