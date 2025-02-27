using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeEvent : MonoBehaviour
{
    private QTEManager _qteManager;

    protected virtual void Start()
    {
        _qteManager = GameObject.FindWithTag("QTEManager").GetComponent<QTEManager>();
        _qteManager.StartQTE();
    }

    private void OnDestroy()
    {
        _qteManager.StopQTE();
    }

    void Update()
    {
        
    }
}
