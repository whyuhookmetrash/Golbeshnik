using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQTE2 : MonoBehaviour
{

    public GameObject point;
    public GameObject startPos;
    private RectTransform pointRect;
    [SerializeField] float pointSpeed = 250f;
    [SerializeField] AudioClip _heartBeatSound_1;
    [SerializeField] GameObject _heartBeatSound_2;
    [SerializeField] GameObject _heartBeatSound_3;
    private List<GameObject> zoneObjects = new List<GameObject>();
    private List<float> zonePoints = new List<float>();
    private string currentZone = "positive";
    private int currentZoneIndex = 0;
    private bool passZone = true;
    private bool doubleClick = false;
    private int passCount = 0;
    private int mistakeCount = 0;
    private SoundManager _soundManager;


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
        _soundManager = gameObject.GetComponent<SoundManager>();
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
        _soundManager.Play(_heartBeatSound_1.name);
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

