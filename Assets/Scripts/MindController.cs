using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MindController : MonoBehaviour
{
    public GameObject hearthBeatQTE;
    [SerializeField] int mindStatus;
    [SerializeField] int maxMindStatus;
    private float currentVignette;

    public void IncreaseMindStatus(int value)
    {
        mindStatus = Mathf.Min(maxMindStatus, mindStatus + value);
        CheckMindStatus();
    }

    public void DecreaseMindStatus(int value)
    {
        mindStatus = Mathf.Max(0, mindStatus - value);
        CheckMindStatus();
    }
    private void CheckMindStatus()
    {
        Debug.Log(mindStatus);
        if (mindStatus == 0)
        {
            StartQTE();
        }
        // добавить реализацию затемнения экрана
    }
    private void StartQTE()
    {
        Debug.Log("StartQTE");
        Instantiate(hearthBeatQTE, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
