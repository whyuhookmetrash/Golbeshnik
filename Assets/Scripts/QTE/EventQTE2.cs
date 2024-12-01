using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQTE2 : MonoBehaviour
{

    public GameObject point;
    public GameObject startPos;
    private RectTransform pointRect;
    [SerializeField] float pointSpeed = 250f;
    private List<GameObject> zoneObjects = new List<GameObject>();
    private List<float> zonePoints = new List<float>();
    private string currentZone = "positive";
    private int currentZoneIndex = 0;
    private bool passZone = true;
    private bool doubleClick = false;
    private int passCount = 0;
    private int mistakeCount = 0;
    void Start()
    {
        pointRect = point.GetComponent<RectTransform>();
        foreach (Transform child in startPos.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject == startPos)
            {
                continue;
            }
            zoneObjects.Add(child.gameObject);
            zonePoints.Add(child.gameObject.GetComponent<RectTransform>().sizeDelta.x / 2 + child.gameObject.GetComponent<RectTransform>().anchoredPosition.x);
        }
    }
    void Update()
    {
        if (pointRect.anchoredPosition.x <= zonePoints[zonePoints.Count - 1])
        {
            pointRect.anchoredPosition = new Vector3(pointRect.anchoredPosition.x + pointSpeed * Time.deltaTime, pointRect.anchoredPosition.y, 0);
        }
        if (currentZoneIndex < zonePoints.Count && pointRect.anchoredPosition.x >= zonePoints[currentZoneIndex])
        {
            CheckZoneOnPass();
            currentZoneIndex += 1;
            if (currentZoneIndex == zonePoints.Count) { StopEvent(); }
            if (currentZone == "positive") 
            { 
                currentZone = "negative";
                passZone = true;
            }
            else 
            {
                currentZone = "positive";
                passZone = false;
            }
            doubleClick = false;
        }
        if (Input.GetButtonDown("CKey") || Input.GetButtonDown("VKey") || Input.GetButtonDown("UKey"))
        {
            if (currentZone == "negative")
            {
                passZone = false;
            }
            else
            {
                if (passZone == false)
                {
                    passZone = true;
                }
                else
                {
                    doubleClick = true;
                }
            }
        }
    }
    void CheckZoneOnPass()
    {
        if (passZone && !doubleClick && currentZone == "positive")
        {
            passCount++;
        }
        else if (!passZone && currentZone == "negative")
        {
            mistakeCount++;
        }
    }
    void StopEvent()
    {
        Debug.Log(passCount);
        Debug.Log(mistakeCount);
    }
}

