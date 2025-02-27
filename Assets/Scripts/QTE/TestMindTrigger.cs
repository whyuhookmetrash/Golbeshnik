using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TestMindTrigger : MonoBehaviour
{
    private MindController _mindController;

    private void Start()
    {
        _mindController = GameObject.FindWithTag("MindController").GetComponent<MindController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mindController.DecreaseMindStatus(1);
        }
    }
}
