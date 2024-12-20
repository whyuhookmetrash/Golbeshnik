using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QTEManager : MonoBehaviour
{
    public event Action StartQTEEvent;
    public event Action EndQTEEvent;
    void Start()
    {
        
    }
    public void StartQTE()
    {
        StartQTEEvent?.Invoke();
    }

    public void StopQTE()
    {
        EndQTEEvent?.Invoke();
    }
}
